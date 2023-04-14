using AutoMapper;
using ConsultorioAPI.DTOs.AsignarTurnoDTOs;
using ConsultorioAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioAPI.Controllers
{
    [ApiController]
    [Route("api/turnos")]
    public class AsignarTurnoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AsignarTurnoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<AsignarTurnoListaDTO>>> Get()
        {
            try
            {
                var turno = await context.AsignarTurno
                .Include(x => x.Paciente)
                .Include(x => x.ServicioEmpleado)
                .ThenInclude(x => x.Empleado)
                .Include(x => x.ServicioEmpleado)
                .ThenInclude(x => x.TipoServicio)
                .ToListAsync();

                return mapper.Map<List<AsignarTurnoListaDTO>>(turno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AsignarTurnoListaDTO>> GetTurno(int id)
        {
            try
            {
                var existe = await context.AsignarTurno.AnyAsync(x => x.Id == id);

                if (!existe)
                {
                    return NotFound("No existe un registro con ese ID");
                }

                var turno = await context.AsignarTurno
                .Include(x => x.Paciente)
                .Include(x => x.ServicioEmpleado)
                .ThenInclude(x => x.Empleado)
                .Include(x => x.ServicioEmpleado)
                .ThenInclude(x => x.TipoServicio)
                .FirstOrDefaultAsync(x => x.Id == id);

                return mapper.Map<AsignarTurnoListaDTO>(turno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(AsignarTurnoCreacionDTO asignarTurno)
        {
            try
            {
                var existeHora = await context.AsignarTurno.AnyAsync(x => x.HoraConsulta == asignarTurno.HoraConsulta);
                var existeServicio = await context.AsignarTurno.AnyAsync(x => x.AsignacionTipoServicioId == asignarTurno.AsignacionTipoServicioId);
                var existePaciente = await context.AsignarTurno.AnyAsync(x => x.PacienteId == asignarTurno.PacienteId);

                if (existeHora && existeServicio)
                {
                    return BadRequest("El paciente ya tiene un turno asignado a esa hora y servicio especifico");
                }

                if (existeHora && existePaciente)
                {
                    return BadRequest("El paciente ya tiene un turno asignado a esa hora y dia especifico");
                }

                var turno = mapper.Map<AsignarTurno>(asignarTurno);

                context.Add(turno);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(AsignarTurnoCreacionDTO asignarTurno, int id)
        {
            try
            {
                var existe = await context.AsignarTurno.AnyAsync(x => x.Id == id);

                if (!existe)
                {
                    return NotFound();
                }

                var asignacion = mapper.Map<AsignarTurno>(asignarTurno);

                if (asignacion.Id != id)
                {
                    return BadRequest("La ID no coincide con ninguna asignacion registrada");
                }

                context.Update(asignacion);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<AsignarTurno>> Delete(int id)
        {
            try
            {
                var asignarTurno = await context.AsignarTurno.FirstOrDefaultAsync(x => x.Id == id);

                if (asignarTurno == null)
                {
                    return NotFound();
                }

                context.AsignarTurno.Remove(asignarTurno);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
