namespace InnovaSystemBussines.Store.Models{
    public class Usuario{
        public int Id { get; set; }
        public int PersonaId {get; set;}
        public int RolId {get;set;}
        public string correo {get;set;}
        public string clave {get;set;}
        public string salt {get;set;}
        public bool Estado {get;set;}
    }

    public class UsuarioBody{
        public int PersonaId {get; set;}
        public int RolId {get;set;}
        public string correo {get;set;}
        public string clave {get;set;}
        public string salt {get;set;}
        public static implicit operator Usuario(UsuarioBody rb) {
            if (rb == null) return null;
            return new Usuario {
                Id = 0,
                PersonaId = rb.PersonaId,
                RolId = rb.RolId,
                correo = rb.correo,
                clave = rb.clave,
                salt = rb.salt,
                Estado = true,
            };
        }
    }
}