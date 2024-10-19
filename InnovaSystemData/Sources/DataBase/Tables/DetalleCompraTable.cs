using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace InnovaSystemData.Sources.DataBase.Tables
{
    [Table("detalleCompra")]
    public class DetalleCompraTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public int cantidadComprada { get; set; }
        [Required]
        [Precision(7, 2)]
        public decimal precioCosto { get; set; }
        [Required]
        [Precision(7, 2)]
        public decimal precioVenta { get; set; }
        [Required]
        public string porcentajeUtilidad { get; set; }
        [Required]
        public DateTime fechaVencimiento { get; set; }
        public int id_compra { get; set; }
        public int id_producto {get;set;}
        [Required]
        public bool estado { get; set; }
        
    }
}