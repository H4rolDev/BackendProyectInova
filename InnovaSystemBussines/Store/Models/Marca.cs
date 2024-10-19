namespace InnovaSystemBussines.Store.Models{
    public class Marca{
        public int Id { get; set; }
        public string Nombre {get;set;}
        public string Descripcion {get;set;}
        public bool Estado {get;set;}
    }

    public class MarcaBody{
        public string Nombre {get;set;}
        public string Descripcion {get;set;}
        public static implicit operator Marca(MarcaBody rb) {
            if (rb == null) return null;
            return new Marca {
                Id = 0,
                Nombre = rb.Nombre,
                Descripcion = rb.Descripcion,
                Estado = true,
            };
        }
    }
}