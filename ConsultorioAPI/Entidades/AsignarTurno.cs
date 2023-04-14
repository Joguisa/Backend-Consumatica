namespace ConsultorioAPI.Entidades
{
    public class AsignarTurno
    {
        public int Id { get; set; }
        public DateTime HoraConsulta { get; set; }
        public int PacienteId { get; set; }
        public int AsignacionTipoServicioId { get; set; }
        public Paciente Paciente { get; set; }
        public AsignacionTipoServicio ServicioEmpleado { get; set; }
    }
}
