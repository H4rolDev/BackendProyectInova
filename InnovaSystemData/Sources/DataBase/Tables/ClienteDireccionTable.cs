using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace InnovaSystemData.Sources.DataBase.Tables
{

    [Table("clienteDireccion")]
    public class ClienteDireccionTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [StringLength(200)]
        public string direccion { get; set; }
        [Required]
        [StringLength(200)]
        public string referencia { get; set; }
        [Required]
        [StringLength(200)]
        public string departamento { get; set; }
        [Required]
        [StringLength(200)]
        public string provincia { get; set; }
        [Required]
        [StringLength(200)]
        public string distrito { get; set; }
        [Required]
        public bool estado { get; set; }
    }
}