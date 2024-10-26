using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace InnovaSystemData.Sources.DataBase.Tables
{
    [Table("ordenServicioTecnico")]

    public class OrdenServicioTecnicoTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public int id_cliente{get;set;}
        [Required]
        public int id_Trabajador{get;set;}
        [Required]
        public DateTime fechaInicio { get; set; }
        [Required]
        public DateTime fechaFin { get; set; }
        [Required]
        public TimeSpan horaInicio { get; set; }
        [Required]
        public TimeSpan horaFin { get; set; }
        [Required]
        public string descripcionServicio { get; set; }
        [Required]
        public decimal precioUnitario { get; set; }
        [Required]
        public decimal total { get; set; }
        [Required]
        public bool estado { get; set; }
        /* public int? id_cliente { get; set; } */
        /* public int? id_Trabajador { get; set; } */
    }
}