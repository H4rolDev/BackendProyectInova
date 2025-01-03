namespace InnovaSystem.Models
{
    public class CustomResponse
    {
        public CustomResponse(bool error = false)
        {
            if (!error)
            {
                this.Code = "Ok";
                this.Message = "La consulta se efectuo correctamente.";
            } else
            {
                this.Code = "Error";
                this.Message = "Los sentimos, tenemos un error.";
            }
        }
        public string Code { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }
    }
}

/* 
{
  "email": "admin@admin.com",
  "password": "Admin!12345",
  "name": "admin",
  "apellidos": "admin",
  "tipo_documento": "DNI",
  "numero_documento": "76040979"
} */