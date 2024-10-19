using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSystemData.Sources.DataBase.Tables
{
    [Table("delivery")]
    public class DeliveryTable
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Range(10000000, 99999999)] // Ajuste de rango para un DNI de 8 dígitos
        public string DNI { get; set; }
        [Required]
        [MaxLength(255)] // Puedes ajustar el tamaño máximo si es necesario
        public string Nombre { get; set; }
        [Required]
        [MaxLength(255)]
        public string Apellidos { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Correo { get; set; }
        [Required]
        [Phone]
        public long Telefono { get; set; }
        public int id_direccion{get;set;}
        public int id_estado { get; set; }
        [Required]
        public bool estado { get; set; }
    }
}