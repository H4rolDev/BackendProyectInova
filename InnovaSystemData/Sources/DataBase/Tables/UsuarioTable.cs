using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace InnovaSystemData.Sources.DataBase.Tables
{
    [Table("users")]
    public class UsuarioTable
    {
        [Key]
        public int id { get; set; }
        public int id_Persona { get; set; }
        public int id_rol {get;set;}
        public string Correo {get;set;}
        [Required]
        public string clave { get; set; }
        [Required]
        public string salt { get; set; }
        [Required]
        public bool estado { get; set; }
    }
}