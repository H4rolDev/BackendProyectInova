namespace InnovaSystemBussines.Store.Models{
    public class Producto{
        public int Id { get; set; }
        public string Nombre {get;set;}
        public string Imagen {get;set;}
        public string Categoria {get;set;}
        public string Descripcion {get;set;}
        public string Modelo {get;set;}
        public string Marca {get;set;}
        public decimal PrecioVenta {get;set;}
        public decimal UtilidadPrecioVenta {get;set;}
        public string UtilidadPorcentaje {get;set;}
        public int Stock {get;set;}
        public int Garantia {get;set;}
        public bool Estado {get;set;}
    }

    public class ProductoBody{
        public string Nombre {get;set;}
        public string Imagen {get;set;}
        public string Categoria {get;set;}
        public string Descripcion {get;set;}
        public string Modelo {get;set;}
        public string Marca {get;set;}
        public decimal PrecioVenta {get;set;}
        public decimal UtilidadPrecioVenta {get;set;}
        public string UtilidadPorcentaje {get;set;}
        public int Stock {get;set;}
        public int Garantia {get;set;}
        public static implicit operator Producto(ProductoBody rb) {
            if (rb == null) return null;
            return new Producto {
                Id = 0,
                Nombre = rb.Nombre,
                Imagen = rb.Imagen,
                Categoria = rb.Categoria,
                Descripcion = rb.Descripcion,
                Modelo = rb.Modelo,
                Marca = rb.Marca,
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