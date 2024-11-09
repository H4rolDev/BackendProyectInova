namespace InnovaSystemBussines.Store.Models{
    public class Cargo{
        public int Id { get; set; }
        public string Nombre {get;set;}
        public string Descripcion {get;set;}
        public decimal SalarioBase {get;set;}
        public bool Estado {get;set;}
    }

    public class CargoBody{
        public string Nombre {get;set;}
        public string Descripcion {get;set;}
        public decimal SalarioBase {get;set;}
        public static implicit operator Cargo(CargoBody rb) {
            if (rb == null) return null;
            return new Cargo {
                Id = 0,
                Nombre = rb.Nombre,
                Descripcion = rb.Descripcion,
                SalarioBase = rb.SalarioBase,
            };
        }
    }
}