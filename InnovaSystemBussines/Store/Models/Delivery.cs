namespace InnovaSystemBussines.Store.Models{
    public class Delivery{
        public int Id { get; set; }
        public int DireccionId{get;set;}
        public int DNI {get;set;}
        public string Nombre {get;set;}
        public string ApellidoPaterno {get;set;}
        public string Email {get;set;}
        public string Telefono {get;set;}
        public bool Estado {get;set;}
    }

    public class DeliveryBody{
        public int DireccionId{get;set;}
        public int DNI {get;set;}
        public string Nombre {get;set;}
        public string ApellidoPaterno {get;set;}
        public string Email {get;set;}
        public string Telefono {get;set;}
        public static implicit operator Delivery(DeliveryBody rb) {
            if (rb == null) return null;
            return new Delivery {
                Id = 0,
                DireccionId = rb.DireccionId,
                DNI = rb.DNI,
                Nombre = rb.Nombre,
                ApellidoPaterno = rb.ApellidoPaterno,
                Email = rb.Email,
                Telefono = rb.Telefono,
                Estado = true,
            };
        }
    }
}