using ConsultorioAPI.Entidades;
using System.ComponentModel.DataAnnotations;

namespace ConsultorioAPI.DTO.EmpleadoDTOs
{
    public class EmpleadoDTO
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        [Required]
        [StringLength(10)]
        public string Cedula { get; set; }
        //public List<AsignacionTipoEmpleadoDTO> Asignacion { get; set; }
        //public List<AsignacionTipoServicioDTO> Servicio { get; set; }

        public AsignacionTipoEmpleadoDTO Asignacion { get; set; }
        public AsignacionTipoServicioDTO Servicio { get; set; }
    }
}
