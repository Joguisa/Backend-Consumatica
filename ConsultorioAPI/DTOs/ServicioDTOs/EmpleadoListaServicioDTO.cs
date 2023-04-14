using System.ComponentModel.DataAnnotations;
using ConsultorioAPI.DTO.EmpleadoDTOs;

namespace ConsultorioAPI.DTO.ServicioDTOs
{
    public class EmpleadoListaServicioDTO
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        [Required]
        [StringLength(10)]
        public string Cedula { get; set; }
        public AsignacionTipoEmpleadoDTO Asignacion { get; set; }
    }
}
