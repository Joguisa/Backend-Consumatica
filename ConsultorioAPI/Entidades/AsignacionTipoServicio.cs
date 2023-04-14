namespace ConsultorioAPI.Entidades
{
    public class AsignacionTipoServicio
    {
        public int Id { get; set; }
        public int EmpleadoId { get; set; }
        public int ServicioId { get; set; }
        public Empleado Empleado { get; set; }
        public Servicio TipoServicio { get; set; }
    }
}
