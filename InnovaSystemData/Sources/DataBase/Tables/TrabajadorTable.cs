    using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace InnovaSystemData.Sources.DataBase.Tables
{
    [Table("Trabajador")]

    public class TrabajadorTable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public int Id_Persona { get; set; }

    [Required]
    public int PuestoId { get; set; }

    // Propiedad de navegación para CargoTable (relación de uno a muchos)
    [ForeignKey("PuestoId")]
    public CargoTable Puesto { get; set; }

    [Required]
    [StringLength(100)]
    public string Nombres { get; set; }
    
    [Required]
    [StringLength(100)]
    public string ApellidoPaterno { get; set; }

    [Required]
    [StringLength(100)]
    public string ApellidoMaterno { get; set; }
    
    public DateTime FechaInicioContrato { get; set; }
    public DateTime FechaFinContrato { get; set; }

    [Required]
    [Precision(7, 2)]
    public decimal Salario { get; set; }

    [Required]
    [Phone]
    public string Telefono { get; set; }

    [Required]
    public bool Estado { get; set; }
}

} 