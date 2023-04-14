using System.ComponentModel.DataAnnotations;

namespace ConsultorioAPI.Entidades
{
    public class Servicio
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreServicio { get; set; }

        public List<AsignacionTipoServicio> AsignacionServicio { get; set; }
    }
}
