using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ConsultorioAPI.Entidades
{
    public class Empleado
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
        public AsignacionTipoEmpleado Asignacion{ get; set; }
        public AsignacionTipoServicio Servicio { get; set; }
    }
}
