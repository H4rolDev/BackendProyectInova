namespace InnovaSystemBussines.Store.Models{
    public class Rol{
        public int Id { get; set; }
        public string Nombre {get;set;}
        public string Descripcion {get;set;}
        public bool Estado {get;set;}
    }

    public class RolBody{
        public string Nombre {get;set;}
        public string Descripcion {get;set;}
        public static implicit operator Rol(RolBody rb) {
            if (rb == null) return null;
            return new Rol {
                Id = 0,
                Nombre = rb.Nombre,
                Descripcion = rb.Descripcion,
                Estado = true,
            };
        }
    }
}