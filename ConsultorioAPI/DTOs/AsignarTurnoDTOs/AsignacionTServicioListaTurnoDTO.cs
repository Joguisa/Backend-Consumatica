using ConsultorioAPI.Entidades;

namespace ConsultorioAPI.DTOs.AsignarTurnoDTOs
{
    public class AsignacionTServicioListaTurnoDTO
    {
        public EmpleadoAsignarTurnoListaDTO Empleado { get; set; }
        public ServicioListaAsignarTurnoDTO TipoServicio { get; set; }
    }
}
