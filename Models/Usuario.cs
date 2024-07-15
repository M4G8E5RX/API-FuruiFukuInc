using System.ComponentModel.DataAnnotations;

namespace API_FuruiFukuInc.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        public string FechaIngreso { get; set; }
        public double ImporteTotalVentas { get; set; }
        [Required]
        public string Puesto { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
