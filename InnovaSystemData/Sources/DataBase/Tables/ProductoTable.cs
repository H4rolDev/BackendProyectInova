using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace InnovaSystemData.Sources.DataBase.Tables
{
    [Table("productos")]
    public class ProductoTable
    {
        [Key]
        public int id { get; set; }
        public int id_categoria { get; set; }
        public int id_marca{get;set;}
        public string nombre {get;set;}
        public string? imagen { get; set; }
        [Required]
        [StringLength(250)]
        public string descripcion { get; set; }
        [Required]
        [StringLength(250)]
        public string modelo { get; set; }
        [Required]
        public decimal precioVenta { get; set; }
        [Required]
        public decimal utilidadPrecioVenta { get; set; }
        [Required]
        public string utilidadPorcentaje { get; set; }
        [Required]
        public int stock { get; set; }
        public int garantia { get; set; }
        [Required]
        public bool estado { get; set; }
    }
}
