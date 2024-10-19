using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace InnovaSystemData.Sources.DataBase.Tables
{
    [Table("proveedores")]

    public class ProveedorTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [StringLength(200)]
        public string nombreContacto { get; set; } 
        [Required]
        [StringLength(200)]
        public string RSocial { get; set; }
        [Required]
        public int RUC { get; set; }
        [Required]
        [Phone]
        public int telefono { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string correo { get; set; }
        [Required]
        public int telefonoContacto { get; set; }
        [Required]
        public string direccion {get;set;}
        public bool estado { get; set; }
          
        

    }
}