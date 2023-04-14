using ConsultorioAPI.Entidades;
using System.ComponentModel.DataAnnotations;

namespace ConsultorioAPI.DTO.TipoEmpleadoDTOs
{
    public class EmpleadoListaTipoEmpleadoDTO
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        //public AsignacionServicioTipoEmpleadoDTO Servicio { get; set; }
    }
}
