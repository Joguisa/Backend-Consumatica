using System.Text.Json.Serialization;

namespace ConsultorioAPI.Entidades
{
    public class AsignacionTipoEmpleado
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public int TipoEmpleadoId { get; set; }
        public Empleado Empleado { get; set;}
        public TipoEmpleado TipoEmpleado { get; set; }
    }
}
