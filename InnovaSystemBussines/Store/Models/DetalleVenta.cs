namespace InnovaSystemBussines.Store.Models{
    public class DetalleVenta{
        public int Id { get; set; }
        public int ProductoId {get;set;}
        public int VentaId {get;set;}
        public decimal PrecioUnitario {get;set;}
        public int Cantidad {get;set;}
        public decimal Impuesto {get;set;}
        public bool Estado {get;set;}
    }

    public class DetalleVentaBody{
        public int ProductoId {get;set;}
        public int VentaId {get;set;}
        public decimal PrecioUnitario {get;set;}
        public int Cantidad {get;set;}
        public decimal Impuesto {get;set;}
        public static implicit operator DetalleVenta(DetalleVentaBody rb) {
            if (rb == null) return null;
            return new DetalleVenta {
                Id = 0,
                ProductoId = rb.ProductoId,
                VentaId = rb.VentaId,
                PrecioUnitario = rb.PrecioUnitario,
                Cantidad = rb.Cantidad,
                Impuesto = rb.Impuesto,
                Estado = true,
            };
        }
    }
}