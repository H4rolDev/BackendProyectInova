using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace InnovaSystemData.Sources.DataBase.Tables
{
    [Table("detalleVenta")]

    public class DetalleVentaTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public int id_producto{get;set;}
        [Required]
        public int id_venta {get;set;}
        [Required]
        [Precision(7, 2)]
        public decimal precioUnitario { get; set; }
        [Required]
        public int cantidad { get; set; }
        [Required]
        [Precision(7, 2)]
        public decimal impuestos { get; set; }
        [Required]
        public bool estado { get; set; }
    }
}