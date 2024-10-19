namespace InnovaSystemBussines.Store.Models{
    public class Categoria{
        public int Id { get; set; }
        public string Nombre {get;set;}
        public string Descripcion {get;set;}
        public bool Estado {get;set;}
    }

    public class CategoriaBody{
        public string Nombre {get;set;}
        public string Descripcion {get;set;}
        public static implicit operator Categoria(CategoriaBody rb) {
            if (rb == null) return null;
            return new Categoria {
                Id = 0,
                Nombre = rb.Nombre,
                Descripcion = rb.Descripcion,
                Estado = true,
            };
        }
    }
}