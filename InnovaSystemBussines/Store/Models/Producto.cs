namespace InnovaSystemBussines.Store.Models{
    public class Producto{
        public int Id { get; set; }
        public int categoriaId {get; set;}
        public int MarcaId {get;set;}
        public string Nombre {get;set;}
        public string Imagen {get;set;}
        public string Descripcion {get;set;}
        public string Modelo {get;set;} 
        public decimal PrecioVenta {get;set;}
        public decimal UtilidadPrecioVenta {get;set;}
        public int UtilidadPorcentaje {get;set;}
        public int Stock {get;set;}
        public int Garantia {get;set;}
        public bool Estado {get;set;}
    }

    public class ProductoBody{
        public string Nombre {get;set;}
        public int CategoriaId {get;set;}
        public int MarcaId {get;set;}
        public string Imagen {get;set;}
        public string Descripcion {get;set;}
        public string Modelo {get;set;}
        public decimal PrecioVenta {get;set;}
        public decimal UtilidadPrecioVenta {get;set;}
        public int UtilidadPorcentaje {get;set;}
        public int Stock {get;set;}
        public int Garantia {get;set;}
        public static implicit operator Producto(ProductoBody rb) {
            if (rb == null) return null;
            return new Producto {
                Id = 0,
                Nombre = rb.Nombre,
                Imagen = rb.Imagen,
                categoriaId = rb.CategoriaId,
                Descripcion = rb.Descripcion,
                Modelo = rb.Modelo,
                MarcaId = rb.MarcaId,
                Stock = rb.Stock,
                PrecioVenta = rb.PrecioVenta,
                UtilidadPrecioVenta = rb.UtilidadPrecioVenta,
                UtilidadPorcentaje = rb.UtilidadPorcentaje,
                Garantia = rb.Garantia,
                Estado = true,
            };
        }
    }
}