using System.ComponentModel.DataAnnotations;

namespace ConsultorioAPI.DTO.EmpleadoDTOs
{
    public class EmpleadoCreacionDTO
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        [Required]
        [StringLength(10)]
        public string Cedula { get; set; }
    }
}
