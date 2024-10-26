using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace InnovaSystemData.Sources.DataBase.Tables
{
    [Table("documentos")]
    public class DocumentoTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string nombre{get; set; }
        [Required]
        public int longitudDocumento { get; set; } 
        [Required]
        public int nroDocumento {get; set;}
        [Required]
        public bool estado { get; set; }
    }
}