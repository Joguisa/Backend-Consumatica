using ConsultorioAPI.Entidades;

namespace ConsultorioAPI.DTO.TipoEmpleadoDTOs
{
    public class TipoEmpleadoListaDTO
    {
        public int Id { get; set; }
        public string NombreTipo { get; set; }
        public List<AsignacionEmpleadoListaDTO> AsignacionTipos { get; set; }
    }
}
