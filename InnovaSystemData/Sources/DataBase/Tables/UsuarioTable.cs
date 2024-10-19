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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int id_cliente { get; set; }
        public int id_rol { get; set; }
        [StringLength(50)]
        public string correo { get; set; }
        [StringLength(512)]
        public string clave { get; set; }
        [StringLength(128)]
        public bool estado { get; set; }

        // public RolTable rol {get; set;}
        // public PersonaTable persona { get; set; }
    }
}