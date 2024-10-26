namespace InnovaSystemBussines.Store.Models{
    public class TipoPago{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado {get;set;}
    }

    public class TipoPagoBody{
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public static implicit operator TipoPago(TipoPagoBody rb) {
            if (rb == null) return null;
            return new TipoPago {
                Id = 0,
                Nombre = rb.Nombre,
                Descripcion = rb.Descripcion,
                Estado = true,
            };
        }
    }
}