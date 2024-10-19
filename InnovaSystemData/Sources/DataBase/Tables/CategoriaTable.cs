using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSystemData.Sources.DataBase.Tables
{
    [Table("categorias")]
    public class CategoriaTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string descripcion { get; set; }
        [Required]
        public bool estado { get; set; }
    }
}