using ConsultorioAPI.Entidades;

namespace ConsultorioAPI.DTO.ServicioDTOs
{
    public class ServicioListaDTO
    {
        public int Id { get; set; }
        public string NombreServicio { get; set; }
        public List<AsignacionServicioListaServicioDTO> AsignacionServicio { get; set; }
    }
}
