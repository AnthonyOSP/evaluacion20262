using System.ComponentModel.DataAnnotations;

namespace evaluacion20262.Models
{
    public class SolicitudServicio
    {
        public int Id { get; set; }

        [Required]
        public string Cliente { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string Distrito { get; set; }

        [Required]
        public string TipoServicio { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
