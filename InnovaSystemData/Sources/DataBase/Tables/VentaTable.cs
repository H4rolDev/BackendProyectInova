using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace InnovaSystemData.Sources.DataBase.Tables
{
    [Table("ventas")]

    public class VentaTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int id_cliente { get; set; }
        public int id_trabajador { get; set; }
        public int id_delivery { get; set; }
        public int id_tipoPago { get; set; }
        public int id_recojoAlmacen { get; set; }
        [Required]
        public DateTime fechaCompra { get; set; }
        [Required]
        [Precision(7, 2)]
        public decimal totalVenta { get; set; }
        [Required]
        public bool estado { get; set; }
        
    }
}