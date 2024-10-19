namespace InnovaSystemBussines.Store.Models{
    public class Cliente{
        public int Id { get; set; }
        public string RazonSocial {get;set;}
        public int Documento {get;set;}
        public string Nombres {get;set;}
        public string Apellidos {get;set;}     
        public int Telefono {get;set;}
        public string Correo {get;set;}
        public string Direccion {get;set;}
        public bool Estado {get;set;}
    }

    public class ClienteBody{
        public string RazonSocial {get;set;}
        public int Documento {get;set;}
        public string Nombres {get;set;}
        public string Apellidos {get;set;}     
        public int Telefono {get;set;}
        public string Correo {get;set;}
        public string Direccion {get;set;}
        public static implicit operator Cliente(ClienteBody rb) {
            if (rb == null) return null;
            return new Cliente {
                Id = 0,
                RazonSocial = rb.RazonSocial,
                Documento = rb.Documento,
                Nombres = rb.Nombres,
                Apellidos = rb.Apellidos,
                Telefono = rb.Telefono,
                Correo = rb.Correo,
                Direccion = rb.Direccion,
                Estado = true,
            };
        }
    }
}