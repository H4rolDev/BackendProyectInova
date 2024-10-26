using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace InnovaSystemData.Sources.DataBase.Tables
{

    [Table("clientes")]
    public class ClienteTable
    {
        [Key]
        public int id { get; set; }
        public int id_Direccion{get;set;}
        [Required]
        public int id_Persona { get; set; } 
        public string? RSocial { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombres { get; set; }
        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; }
        [Required]
        [Phone]
        public int telefono { get; set; }
        [Required]
        [StringLength(100)]
        public string correo { get; set; }
        [Required]
        public string TipoDocumento {get;set;}
        [Required]
        public int NumeroDocumento {get;set;}
        [Required]
        public bool estado { get; set; }
    }
}