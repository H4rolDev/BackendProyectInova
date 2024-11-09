public class TrabajadorDto
{
    public int Id { get; set; }
    public string Nombres { get; set; }
    public string ApellidoPaterno { get; set; }
    public string ApellidoMaterno { get; set; }
    public DateTime FechaInicioContrato{get;set;}
    public DateTime FechaFinContrato{get;set;}
    public string Telefono { get; set; }
    public decimal Salario { get; set; }
    public string NombrePuesto { get; set; }
    
}