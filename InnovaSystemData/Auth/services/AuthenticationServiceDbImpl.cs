using System.Security.Cryptography;
using System.Text;
using InnovaSystemBussines.Auth.models;
using InnovaSystemBussines.Auth.services;
using InnovaSystemBussines.Errors;
using InnovaSystemData.Sources.DataBase;
using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemData.Utils;
using Microsoft.Extensions.Logging;

namespace InnovaSystemData.Auth.services{
    public class AuthenticactionServiceDbImpl: IAuthenticationService
    {
        private readonly InnovaDbContext _db;
        public readonly ILogger _logger;
        public AuthenticactionServiceDbImpl(
            ILogger<AuthenticactionServiceDbImpl> logger,
            InnovaDbContext db) {
            _db = db;
            _logger = logger;
        }
        public LoginResponse Login(LoginRequest login)
        {
            var user = _db.usuarios.Where(u=>u.Correo == login.email).FirstOrDefault();
            if(user == null){
                throw new MessageExeption("Credenciales incorrectas.");
            }
            login.password = GenerateSaltedHash(login.password, user.salt);
            _logger.LogInformation($"HASHED PASSWORD =====> {login.password}");

            var userData = _db.usuarios.Join(
                _db.personas,
                u => u.id_Persona,
                p => p.id,
                (u, p) => new{u=u, p=p}
            ).Join(
                _db.roles,
                (up) => up.u.id_rol,
                r => r.id,
                (up, r) => new {u=up.u, p=up.p, r=r} 
            ).Where(
                (upr) => upr.u.Correo == login.email && upr.u.clave == login.password && upr.u.estado
            ).FirstOrDefault();

            if (userData == null){
                throw new MessageExeption("cerdenciales incorrectas.");
            }
            var profile = new UserAppProfile {
                Id = userData.u.id,
                Names = userData.p.nombres,
                LastName = userData.p.apellidos,
                Email = userData.u.Correo,
                Rol = new RolApp {
                    name = userData.r.nombre,
                    Id = userData.r.id
                }
            };

            return new LoginResponse {
                token = JwtUtils.Encode(profile),
                profile = profile,
            };

            /* 
            var user = _db.usuario.Where(
                (u) => u.correo == login.email && u.clave == login.password && u.Estado
            ).FirstOrDefault();

            if(user != null){
                var persona = _db.personas.Where(p=>p.id== user.id_persona).FirstOrDefault();
                var rol = _db.roles.Where(r => r.id == user.id_rol).FirstOrDefault();
            }
             */
        }

        public void Register(RegisterRequest data)
        {
            int CLIENTE_ROL = 2;
            // CREAR persona
            var person = new PersonaTable{
                nombres = data.Name,
                apellidos = data.apellidos,
                tipo_documento = data.tipo_documento,
                numero_documento = data.numero_documento,
                estado = true
            };
            _db.personas.Add(person);
            _db.SaveChanges();

            //CREAR USUARIO
            // -> creamos el salt
            string salt = CreateSalt();
            //-> Remplazar la contraseña
            data.Password = GenerateSaltedHash(data.Password, salt);
        
            var user = new UsuarioTable{
                id_Persona = person.id,
                id_rol = CLIENTE_ROL,
                Correo = data.Email,
                clave = data.Password,
                salt = salt,
                estado = true
            };

            _db.usuarios.Add(user);
            _db.SaveChanges();
        }
        private static string GenerateSaltedHash(string passwordStr, string saltStr)
        {
            //var utf8 = new UTF8Encoding();

            byte[] password = Encoding.ASCII.GetBytes(passwordStr);
            byte[] salt = Encoding.ASCII.GetBytes(saltStr);
            
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes = 
                new byte[password.Length + salt.Length];

            for (int i = 0; i < password.Length; i++)
            {
                plainTextWithSaltBytes[i] = password[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[password.Length + i] = salt[i];
            }

            byte[] hashedPwd = algorithm.ComputeHash(plainTextWithSaltBytes);            
            return Convert.ToBase64String(hashedPwd);
        }
        private static string CreateSalt(int size = 64)
        {
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(buff);
        }
    }
}