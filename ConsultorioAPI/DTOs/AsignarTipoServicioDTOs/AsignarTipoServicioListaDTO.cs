using ConsultorioAPI.Entidades;

namespace ConsultorioAPI.DTOs.AsignarTipoServicioDTOs
{
    public class AsignarTipoServicioListaDTO
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public int ServicioId { get; set; }
        public EmpleadoAsignacionListaTipoServicioDTO Empleado { get; set; }
        public AsignacionTipoServicoListaServicioDTO TipoServicio { get; set; }
    }
}
