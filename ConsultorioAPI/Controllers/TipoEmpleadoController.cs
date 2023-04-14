using AutoMapper;
using ConsultorioAPI.DTO.TipoEmpleadoDTOs;
using ConsultorioAPI.DTOs.TipoEmpleadoDTOs;
using ConsultorioAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioAPI.Controllers
{
    [ApiController]
    [Route("api/tipoEmpleado")]
    public class TipoEmpleadoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TipoEmpleadoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoEmpleadoListaDTO>>> Get()
        {
            try
            {
                var tipoEmpleado = await context.TipoEmpleados
                .Include(x => x.AsignacionTipos)
                .ThenInclude(x => x.Empleado)
                .ThenInclude(x => x.Servicio)
                .ThenInclude(x => x.TipoServicio)
                .ToListAsync();

                return mapper.Map<List<TipoEmpleadoListaDTO>>(tipoEmpleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TipoEmpleadoListaDTO>> GetTurno(int id)
        {
            try
            {
                var existe = await context.TipoEmpleados.AnyAsync(x => x.Id == id);

                if (!existe)
                {
                    return NotFound("No existe un registro con ese ID");
                }

                var tipoEmpleado = await context.TipoEmpleados
                    .Include(x => x.AsignacionTipos)
                    .ThenInclude(x => x.Empleado)
                    .ThenInclude(x => x.Servicio)
                    .ThenInclude(x => x.TipoServicio)
                    .FirstOrDefaultAsync(x => x.Id == id);

                return mapper.Map<TipoEmpleadoListaDTO>(tipoEmpleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }         
        }

        [HttpPost]
        public async Task<ActionResult> Post(TipoEmpleadoCreacionDTO tipoEmpleadoCreacionDTO)
        {
            try
            {
                var existe = await context.TipoEmpleados.AnyAsync(x => x.NombreTipo == tipoEmpleadoCreacionDTO.NombreTipo);

                if (existe)
                {
                    return BadRequest("El tipo de empleado ya se encuentra registrado");
                }
                var tipoEmpleado = mapper.Map<TipoEmpleado>(tipoEmpleadoCreacionDTO);

                context.Add(tipoEmpleado);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }          
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(TipoEmpleadoCreacionDTO tipoEmpleadoCreacionDTO, int id)
        {
            try
            {
                var existe = await context.TipoEmpleados.AnyAsync(x => x.Id == id);

                if (!existe)
                {
                    return NotFound();
                }

                var tipoEmpleado = mapper.Map<TipoEmpleado>(tipoEmpleadoCreacionDTO);

                if (tipoEmpleado.Id != id)
                {
                    return BadRequest("La ID no coincide con ningun puesto registrado");
                }

                context.Update(tipoEmpleado);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TipoEmpleado>> Delete(int id)
        {
            try
            {
                var tipoEmpleado = await context.TipoEmpleados.FirstOrDefaultAsync(x => x.Id == id);

                if (tipoEmpleado == null)
                {
                    return NotFound();
                }

                context.TipoEmpleados.Remove(tipoEmpleado);
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
