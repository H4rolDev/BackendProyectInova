namespace InnovaSystemBussines.Store.Models{
    public class Venta{
        public int Id { get; set; }
        public int ClienteId {get;set;}
        public int TrabajadorId {get;set;}
        public int DeliveryId {get;set;}
        public int TipoPagoId {get;set;}
        public int RecojoAlmacenId {get;set;}
        public DateTime FechaCompra {get;set;}
        public decimal TotalVenta {get;set;}
        public bool Estado {get;set;}
    }

    public class VentaBody{
        public int ClienteId {get;set;}
        public int TrabajadorId {get;set;}
        public int DeliveryId {get;set;}
        public int TipoPagoId {get;set;}
        public int RecojoAlmacenId {get;set;}
        public DateTime FechaCompra {get;set;}
        public decimal TotalVenta {get;set;}
        public static implicit operator Venta(VentaBody rb) {
            if (rb == null) return null;
            return new Venta {
                Id = 0,
                ClienteId = rb.ClienteId,
                TrabajadorId = rb.TrabajadorId,
                DeliveryId = rb.DeliveryId,
                TipoPagoId = rb.TipoPagoId,
                RecojoAlmacenId = rb.RecojoAlmacenId,
                FechaCompra = rb.FechaCompra,
                TotalVenta = rb.TotalVenta,
                Estado = true,
            };
        }
    }
}