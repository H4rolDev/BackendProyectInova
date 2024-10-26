using InnovaSystemBussines.Errors;
using InnovaSystemBussines.Store.Models;
using InnovaSystemBussines.Store.Services;
using InnovaSystemData.Sources.DataBase;
using InnovaSystemData.Sources.DataBase.Tables;
using InnovaSystemData.Store.Extentions;

namespace  InnovaSystemData.Store.Services {
    public class UsuarioServiceDbImpl : IUsuarioService
    {
        private readonly InnovaDbContext _db;
        public UsuarioServiceDbImpl(InnovaDbContext db) {
            _db = db;
        }
        public Usuario Create(Usuario entity)
        {
            UsuarioTable usuarioTable = entity.ToTable();
            _db.usuarios.Add(usuarioTable);
            int r = _db.SaveChanges();
            if (r == 1)
            {
                entity.Id = usuarioTable.id;
                return entity;
            }
            else
            {
                throw new MessageExeption("No se pudo insertar este Usuario");
            }
        }
        public void Delete(int id)
        {
            UsuarioTable? usuarioTable = _db.usuarios.FirstOrDefault(r => r.id == id && r.estado);
            if (usuarioTable == null) throw new MessageExeption("No se encontro el Usuario");
            //_db.proveedores.Remove(proveedorTable);
            usuarioTable.estado = false;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar el Usuario");
        }
        public List<Usuario> GetAll()
        {
            List<Usuario> usuario = _db.usuarios
                .Where(r => r.estado)
                .Select<UsuarioTable, Usuario>(
                    rt => rt.ToModel()
                ).ToList();
            return usuario;
        }

        public Usuario? GetById(int id)
        {
            UsuarioTable? usuario = _db.usuarios
                .FirstOrDefault(r => r.id == id && r.estado);
            if (usuario == null) return null;
            return usuario.ToModel();
        }

        public void Update(int id, Usuario body)
        {
            UsuarioTable? usuario = _db.usuarios
                .FirstOrDefault(r => r.id == id && r.estado);
            if (usuario == null) throw new MessageExeption("No se encontro el Usuario");
            usuario.id_rol = body.RolId;
            usuario.id_Persona = body.PersonaId;
            usuario.Correo = body.correo;
            usuario.clave = body.clave;
            usuario.salt = body.salt;
            int r = _db.SaveChanges();
            if (r == 1) return;
            else throw new MessageExeption("No se pudo eliminar el Usuario");
        }
    }
}