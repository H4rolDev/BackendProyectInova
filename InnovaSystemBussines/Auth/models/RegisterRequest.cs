namespace InnovaSystemBussines.Auth.models{
    public class RegisterRequest{
        public string Email {get;set;}
        public string Password {get;set;}
        public string Name { get; set; }
        public string apellidos { get; set; }
        public string tipo_documento { get; set; }
        public string numero_documento { get; set; }
    }
}