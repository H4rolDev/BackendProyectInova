using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace InnovaSystemData.Sources.DataBase.Tables
{
    [Table("Compra")]

    public class CompraTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public DateTime fechaCompra { get; set; }
        [Required]
        public string metodoPago { get; set; }
        [Required]
        public string idTipoDocEntrada { get; set; }
        [Required]
        public int nroDocEntrada { get; set; }
        public int id_proveedor { get; set; }
        public int id_estado { get; set; }
        [Required]
        public bool estado { get; set; }
    }
}