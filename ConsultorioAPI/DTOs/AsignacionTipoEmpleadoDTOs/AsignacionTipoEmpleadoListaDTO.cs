using ConsultorioAPI.Entidades;

namespace ConsultorioAPI.DTOs.AsignacionTipoEmpleadoDTOs
{
    public class AsignacionTipoEmpleadoListaDTO
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public int TipoEmpleadoId { get; set; }
        public EmpleadoAsignacionTipoLista Empleado { get; set; }
        public TipoEmpleadoListaAsignacion TipoEmpleado { get; set; }
    }
}
