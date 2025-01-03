namespace InnovaSystemBussines.Store.Models{
    public class Trabajador{
        public int Id { get; set; }
        public int PersonaId{get;set;}
        public string Nombre {get;set;}
        public string ApellidoPaterno {get;set;}
        public string ApellidoMaterno {get;set;}
        public DateTime FechaInicioContrato {get;set;}   
        public DateTime FechaFinContrato {get;set;} 
        public int PuestoId {get;set;}
        public decimal Salario {get;set;}
        public string Telefono {get;set;}
        public bool Estado {get;set;}
    }

    public class TrabajadorBody{
        public int PersonaId{get;set;}
        public string Nombre {get;set;}
        public string ApellidoPaterno {get;set;}
        public string ApellidoMaterno {get;set;}
        public DateTime FechaInicioContrato {get;set;}   
        public DateTime FechaFinContrato {get;set;} 
        public int PuestoId {get;set;}
        public decimal Salario {get;set;}
        public string Telefono {get;set;}
        public static implicit operator Trabajador(TrabajadorBody rb) {
            if (rb == null) return null;
            return new Trabajador {
                Id = 0,
                PersonaId = rb.PersonaId,
                Nombre = rb.Nombre,
                ApellidoPaterno = rb.ApellidoPaterno,
                ApellidoMaterno = rb.ApellidoMaterno,
                FechaInicioContrato = rb.FechaInicioContrato,
                FechaFinContrato = rb.FechaFinContrato,
                PuestoId = rb.PuestoId,
                Salario = rb.Salario,
                Telefono = rb.Telefono,
                Estado = true,
            };
        }
    }
}