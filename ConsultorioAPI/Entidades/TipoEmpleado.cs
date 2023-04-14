using System.ComponentModel.DataAnnotations;

namespace ConsultorioAPI.Entidades
{
    public class TipoEmpleado
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreTipo { get; set; }

        public List<AsignacionTipoEmpleado> AsignacionTipos { get;set; }
    }
}
