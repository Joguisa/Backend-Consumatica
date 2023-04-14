using System.ComponentModel.DataAnnotations;

namespace ConsultorioAPI.Entidades
{
    public class Paciente
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(10)]
        public string Cedula { get; set; }
    }
}
