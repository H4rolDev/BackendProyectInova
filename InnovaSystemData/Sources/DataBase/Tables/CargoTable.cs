using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace InnovaSystemData.Sources.DataBase.Tables
{

    [Table("Cargo")]
    public class CargoTable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    [Required]
    public string nombre { get; set; }
    public string descripcion { get; set; }
    [Required]
    [Precision(7, 2)]
    public decimal salarioBase { get; set; }
    public bool Estado { get; set; }

    // Propiedad de navegación para la lista de trabajadores
    public ICollection<TrabajadorTable> Trabajadores { get; set; }
}

}