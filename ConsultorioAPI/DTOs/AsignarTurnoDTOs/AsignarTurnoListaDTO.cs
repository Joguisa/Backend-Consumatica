using ConsultorioAPI.Entidades;

namespace ConsultorioAPI.DTOs.AsignarTurnoDTOs
{
    public class AsignarTurnoListaDTO
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int AsignacionTipoServicioId { get; set; }
        public PacienteListaTurnoDTO Paciente { get; set; }
        public AsignacionTServicioListaTurnoDTO ServicioEmpleado { get; set; }
        public DateTime HoraConsulta { get; set; }
    }
}
