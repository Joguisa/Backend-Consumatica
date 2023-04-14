using AutoMapper;
using ConsultorioAPI.DTO.EmpleadoDTOs;
using ConsultorioAPI.DTOs.AsignacionTipoEmpleadoDTOs;
using ConsultorioAPI.DTOs.AsignarTipoServicioDTOs;
using ConsultorioAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioAPI.Controllers
{
    [ApiController]
    [Route("api/asignacionEmpleado")]
    public class AsignacionTipoEmpleadoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AsignacionTipoEmpleadoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<AsignacionTipoEmpleadoListaDTO>>> Get()
        {
            try
            {
                var asignacionEmpleado = await context.AsignarEmpleado
               .Include(x => x.Empleado)
               .Include(x => x.TipoEmpleado)
               .ToListAsync();

                return mapper.Map<List<AsignacionTipoEmpleadoListaDTO>>(asignacionEmpleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AsignacionTipoEmpleadoListaDTO>> GetTipoEmpleado(int id)
        {
            try
            {
                var existe = await context.AsignarEmpleado.AnyAsync(x => x.Id == id);

                if (!existe)
                {
                    return NotFound("No existe un registro con ese ID");
                }

                var asignacionEmpleado = await context.AsignarEmpleado
                   .Include(x => x.Empleado)
                   .Include(x => x.TipoEmpleado)
                   .FirstOrDefaultAsync(x => x.Id == id);

                return mapper.Map<AsignacionTipoEmpleadoListaDTO>(asignacionEmpleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(AsignacionTipoEmpladoCreacionDTO asignacionTipoEmpladoCreacionDTO)
        {
            try
            {
                var existe = await context.AsignarEmpleado.AnyAsync(x => x.EmpleadoId == asignacionTipoEmpladoCreacionDTO.EmpleadoId);

                if (existe)
                {
                    return BadRequest("El empleado ya esta asignado a un tipo de empleado");
                }

                var asignacion = mapper.Map<AsignacionTipoEmpleado>(asignacionTipoEmpladoCreacionDTO);

                context.Add(asignacion);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }        
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(AsignacionTipoEmpladoCreacionDTO asignacionTipoEmpladoCreacionDTO, int id)
        {
            try
            {
                var existe = await context.AsignarEmpleado.AnyAsync(x => x.Id == id);

                if (!existe)
                {
                    return NotFound();
                }

                var asignacion = mapper.Map<AsignacionTipoEmpleado>(asignacionTipoEmpladoCreacionDTO);

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
        public async Task<ActionResult<AsignacionTipoEmpleado>> Delete(int id)
        {
            try
            {
                var asignarEmpleado = await context.AsignarEmpleado.FirstOrDefaultAsync(x => x.Id == id);

                if (asignarEmpleado == null)
                {
                    return NotFound();
                }

                context.AsignarEmpleado.Remove(asignarEmpleado);
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