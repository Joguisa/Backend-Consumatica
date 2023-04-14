namespace ConsultorioAPI.DTOs.AsignarTurnoDTOs
{
    public class AsignarTurnoCreacionDTO
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int AsignacionTipoServicioId { get; set; }
        public DateTime HoraConsulta { get; set; }
    }
}
