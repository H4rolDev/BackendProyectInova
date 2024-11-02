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
        public int id { get; set; }
        public int id_Persona { get; set; }
        [Required]
        public int id_Puesto {get;set;}
        [Required]
        [StringLength(100)]
        public string nombres { get; set; }
        [Required]
        [StringLength(100)]
        public string apellidoPaterno { get; set; }
        [Required]
        [StringLength(100)]
        public string apellidoMaterno { get; set; }
        public DateTime FechaInicioContrato {get;set;}   
        public DateTime FechaFinContrato {get;set;}   
        [Required]
        [Precision(18,2)]
        public decimal salario { get; set; }
        [Required]
        [Phone]
        public string telefono { get; set; } 
        [Required]
        public bool estado { get; set; }
    }
}