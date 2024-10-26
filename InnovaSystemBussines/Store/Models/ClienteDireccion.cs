namespace InnovaSystemBussines.Store.Models{
    public class ClienteDireccion{
        public int Id { get; set; }
        public string Direccion {get;set;}
        public string Referencia {get;set;}
        public string Departamento {get;set;}    
        public string Provincia {get;set;}
        public string Distrito {get;set;}     
        public bool Estado {get;set;}
    }

    public class ClienteDireccionBody{
        public string Direccion {get;set;}
        public string Referencia {get;set;}
        public string Departamento {get;set;}    
        public string Provincia {get;set;}
        public string Distrito {get;set;} 

        public static implicit operator ClienteDireccion(ClienteDireccionBody rb) {
            if (rb == null) return null;
            return new ClienteDireccion {
                Id = 0,
                Direccion = rb.Direccion,
                Referencia = rb.Referencia,
                Departamento = rb.Departamento,
                Provincia = rb.Provincia,
                Distrito = rb.Distrito,
                Estado = true,
            };
        }
    }
}