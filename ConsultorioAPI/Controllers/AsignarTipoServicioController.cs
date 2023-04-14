using AutoMapper;
using ConsultorioAPI.DTOs.AsignarTipoServicioDTOs;
using ConsultorioAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioAPI.Controllers
{
    [ApiController]
    [Route("api/asignarServicio")]
    public class AsignarTipoServicioController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AsignarTipoServicioController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<AsignarTipoServicioListaDTO>>> Get()
        {
            try
            {
                var asignacionServicio = await context.AsignarServicio
                .Include(x => x.Empleado)
                .Include(x => x.TipoServicio)
                .ToListAsync();

                return mapper.Map<List<AsignarTipoServicioListaDTO>>(asignacionServicio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AsignarTipoServicioListaDTO>> GetTipoServicio(int id)
        {
            try
            {
                var existe = await context.AsignarServicio.AnyAsync(x => x.Id == id);

                if (!existe)
                {
                    return NotFound("No existe un registro con ese ID");
                }

                var asignacionServicio = await context.AsignarServicio
                    .Include(x => x.Empleado)
                    .Include(x => x.TipoServicio)
                    .FirstOrDefaultAsync(x => x.Id == id);

                return mapper.Map<AsignarTipoServicioListaDTO>(asignacionServicio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(AsignacionTipoServicioCreacionDTO asignacionTipoServicioCreacionDTO)
        {
            try
            {
                var existe = await context.AsignarServicio.AnyAsync(x => x.EmpleadoId == asignacionTipoServicioCreacionDTO.EmpleadoId);

                if (existe)
                {
                    return BadRequest("El empleado ya esta asignado a un servicio");
                }

                var asignacion = mapper.Map<AsignacionTipoServicio>(asignacionTipoServicioCreacionDTO);

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
        public async Task<ActionResult> Put(AsignacionTipoServicioCreacionDTO asignacionTipoServicioCreacionDTO, int id)
        {
            try
            {
                var existe = await context.AsignarServicio.AnyAsync(x => x.Id == id);

                if (!existe)
                {
                    return NotFound();
                }

                var asignacion = mapper.Map<AsignacionTipoServicio>(asignacionTipoServicioCreacionDTO);

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
        public async Task<ActionResult<AsignacionTipoServicio>> Delete(int id)
        {
            try
            {
                var asignarservicio = await context.AsignarServicio.FirstOrDefaultAsync(x => x.Id == id);

                if (asignarservicio == null)
                {
                    return NotFound("La Id no coincide a ningun registro");
                }

                context.AsignarServicio.Remove(asignarservicio);
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
