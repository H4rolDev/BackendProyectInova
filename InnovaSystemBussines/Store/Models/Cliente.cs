namespace InnovaSystemBussines.Store.Models{
    public class Cliente{
        public int Id { get; set; }
        public int PersonaId{get;set;}
        public int DireccionId {get;set;}
        public string RazonSocial {get;set;}    
        public string Nombres {get;set;}
        public string Apellidos {get;set;}     
        public int Telefono {get;set;}
        public string Correo {get;set;}
        public string TipoDocumento {get;set;}
        public int NumeroDocumento {get;set;}
        public bool Estado {get;set;}
    }

    public class ClienteBody{
        public int PersonaId{get;set;}

        public int DireccionId {get;set;}
        public string? RazonSocial {get;set;}    
        public string Nombres {get;set;}
        public string Apellidos {get;set;}     
        public int Telefono {get;set;}
        public string Correo {get;set;}
        public string TipoDocumento {get;set;}
        public int NumeroDocumento {get;set;}

        public static implicit operator Cliente(ClienteBody rb) {
            if (rb == null) return null;
            return new Cliente {
                Id = 0,
                PersonaId = rb.PersonaId,
                DireccionId = rb.DireccionId,
                RazonSocial = rb.RazonSocial,
                Nombres = rb.Nombres,
                Apellidos = rb.Apellidos,
                Telefono = rb.Telefono,
                Correo = rb.Correo,
                TipoDocumento = rb.TipoDocumento,
                NumeroDocumento = rb.NumeroDocumento,
                Estado = true,
            };
        }
    }
}