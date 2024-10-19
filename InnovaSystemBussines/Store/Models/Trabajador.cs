namespace InnovaSystemBussines.Store.Models{
    public class Trabajador{
        public int Id { get; set; }
        public string Nombre {get;set;}
        public string ApellidoPaterno {get;set;}
        public string ApellidoMaterno {get;set;}
        public DateTime FechaInicioContrato {get;set;}   
        public DateTime FechaFinContrato {get;set;} 
        public string Puesto {get;set;}
        public decimal Salario {get;set;}
        public string Telefono {get;set;}
        public bool Estado {get;set;}
    }

    public class TrabajadorBody{
        public string Nombre {get;set;}
        public string ApellidoPaterno {get;set;}
        public string ApellidoMaterno {get;set;}
        public DateTime FechaInicioContrato {get;set;}   
        public DateTime FechaFinContrato {get;set;} 
        public string Puesto {get;set;}
        public decimal Salario {get;set;}
        public string Telefono {get;set;}
        public static implicit operator Trabajador(TrabajadorBody rb) {
            if (rb == null) return null;
            return new Trabajador {
                Id = 0,
                Nombre = rb.Nombre,
                ApellidoPaterno = rb.ApellidoPaterno,
                ApellidoMaterno = rb.ApellidoMaterno,
                FechaInicioContrato = rb.FechaInicioContrato,
                FechaFinContrato = rb.FechaFinContrato,
                Puesto = rb.Puesto,
                Salario = rb.Salario,
                Telefono = rb.Telefono,
                Estado = true,
            };
        }
    }
}