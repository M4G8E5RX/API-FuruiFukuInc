using System.ComponentModel.DataAnnotations;

namespace API_FuruiFukuInc.Models
{
    public class Ventas
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DescripcionArticulo { get; set; }
        [Required]
        public string FechaVenta { get; set; }
        [Required]
        public double ImporteVenta { get; set; }
        public string EstatusVenta { get; set; }
        public string EstatusSupervision { get; set; }
    }
}
