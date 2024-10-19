namespace InnovaSystemBussines.Store.Models{
    public class Proveedor{
        public int Id { get; set; }
        public string PersonaContacto {get;set;}
        public string RazonSocial {get;set;}
        public int RUC {get;set;}
        public int Telefono {get;set;}
        public string CorreoElectronico {get;set;}
        public string Direccion {get;set;}
        public bool Estado {get;set;}
    }

    public class ProveedorBody{
        public string PersonaContacto {get;set;}
        public string RazonSocial {get;set;}
        public int RUC {get;set;}
        public int Telefono {get;set;}
        public string CorreoElectronico {get;set;}
        public string Direccion {get;set;}
        public static implicit operator Proveedor(ProveedorBody rb) {
            if (rb == null) return null;
            return new Proveedor {
                Id = 0,
                PersonaContacto = rb.PersonaContacto,
                RazonSocial = rb.RazonSocial,
                RUC = rb.RUC,
                CorreoElectronico = rb.CorreoElectronico,
                Direccion = rb.Direccion,
                Estado = true,
            };
        }
    }
}