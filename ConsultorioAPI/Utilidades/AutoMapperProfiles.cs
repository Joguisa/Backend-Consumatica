using AutoMapper;
using ConsultorioAPI.DTO.EmpleadoDTOs;
using ConsultorioAPI.DTO.ServicioDTOs;
using ConsultorioAPI.DTO.TipoEmpleadoDTOs;
using ConsultorioAPI.DTOs.AsignacionTipoEmpleadoDTOs;
using ConsultorioAPI.DTOs.AsignarTipoServicioDTOs;
using ConsultorioAPI.DTOs.AsignarTurnoDTOs;
using ConsultorioAPI.DTOs.TipoEmpleadoDTOs;
using ConsultorioAPI.Entidades;

namespace ConsultorioAPI.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //post
            CreateMap<EmpleadoCreacionDTO, Empleado>();
            CreateMap<ServicioCreacionDTO, Servicio>();
            CreateMap<AsignacionTipoEmpladoCreacionDTO, AsignacionTipoEmpleado>();
            CreateMap<AsignarTurnoCreacionDTO, AsignarTurno>();
            CreateMap<AsignacionTipoServicioCreacionDTO, AsignacionTipoServicio>();
            CreateMap<TipoEmpleadoCreacionDTO, TipoEmpleado>();

            //get
            CreateMap<Empleado, EmpleadoDTO>();
            CreateMap<AsignacionTipoEmpleado, AsignacionTipoEmpleadoDTO>();
            CreateMap<TipoEmpleado, TipoEmpleadoDTO>();

            CreateMap<AsignacionTipoServicio, AsignacionTipoServicioDTO>();
            CreateMap<Servicio, ServicioDTO>();

            CreateMap<Empleado, EmpleadoListaServicioDTO>();
            CreateMap<AsignacionTipoServicio, AsignacionServicioListaServicioDTO>();
            CreateMap<Servicio, ServicioListaDTO>();

            CreateMap<TipoEmpleado, TipoEmpleadoListaDTO>();
            CreateMap<AsignacionTipoEmpleado, AsignacionEmpleadoListaDTO>();
            CreateMap<Empleado, EmpleadoListaTipoEmpleadoDTO>();
            CreateMap<AsignacionTipoServicio, AsignacionServicioTipoEmpleadoDTO>();
            CreateMap<Servicio, ServicioListaTipoEmpleadoDTO>();

            CreateMap<AsignacionTipoEmpleado, AsignacionTipoEmpleadoListaDTO>();
            CreateMap<Empleado, AsignacionTipoEmpleadoListaDTO>();
            CreateMap<TipoEmpleado, TipoEmpleadoListaAsignacion>();

            CreateMap<AsignacionTipoServicio, AsignarTipoServicioListaDTO>();
            CreateMap<Empleado, EmpleadoAsignacionListaTipoServicioDTO>();
            CreateMap<Servicio, AsignacionTipoServicoListaServicioDTO>();

            CreateMap<Paciente, PacienteListaTurnoDTO>();
            CreateMap<AsignarTurno, AsignarTurnoListaDTO>();
            CreateMap<AsignacionTipoServicio, AsignacionTipoServicoListaServicioDTO>();
            CreateMap<Servicio, AsignacionTServicioListaTurnoDTO>();
        }
    }
}
