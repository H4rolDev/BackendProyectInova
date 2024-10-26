using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace InnovaSystemData.Sources.DataBase.Tables
{
    [Table("persona")]
    public class PersonaTable
    {
        [Key]
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string tipo_documento { get; set; }
        public string numero_documento { get; set; }
        public string telefono { get; set; }
        public bool estado { get; set; }

        //public UsuarioTable? usuario { get; set;}
    }

}
