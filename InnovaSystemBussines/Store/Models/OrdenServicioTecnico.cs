namespace InnovaSystemBussines.Store.Models{
    public class OrdenServicioTecnico{
        public int Id { get; set; }
        public string Cliente {get;set;}
        public string Trabajador {get;set;}
        public DateTime FechaInicio {get;set;}
        public DateTime FechFin {get;set;}
        public TimeSpan HoraInicio {get;set;}
        public TimeSpan HoraFin {get;set;}
        public string DescripcionServicio {get;set;}
        public decimal PrecioUnitario {get;set;}
        public decimal Total {get;set;}
        public bool Estado {get;set;}
    }

    public class OrdenServicioTecnicoBody{
        public string Cliente {get;set;}
        public string Trabajador {get;set;}
        public DateTime FechaInicio {get;set;}
        public DateTime FechFin {get;set;}
        public TimeSpan HoraInicio {get;set;}
        public TimeSpan HoraFin {get;set;}
        public string DescripcionServicio {get;set;}
        public decimal PrecioUnitario {get;set;}
        public decimal Total {get;set;}
        public static implicit operator OrdenServicioTecnico(OrdenServicioTecnicoBody rb) {
            if (rb == null) return null;
            return new OrdenServicioTecnico {
                Id = 0,
                Cliente = rb.Cliente,
                Trabajador = rb.Trabajador,
                FechaInicio = rb.FechaInicio,
                FechFin = rb.FechFin,
                HoraInicio = rb.HoraInicio,
                HoraFin = rb.HoraFin,
                DescripcionServicio = rb.DescripcionServicio,
                PrecioUnitario = rb.PrecioUnitario,
                Total = rb.Total,
                Estado = true,
            };
        }
    }
}