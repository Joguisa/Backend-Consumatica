using AutoMapper;
using ConsultorioAPI.DTO.ServicioDTOs;
using ConsultorioAPI.DTOs.AsignacionTipoEmpleadoDTOs;
using ConsultorioAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioAPI.Controllers
{
    [ApiController]
    [Route("api/servicios")]
    public class ServicioController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ServicioController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ServicioListaDTO>>> Get()
        {
            try
            {
                var servicio = await context.Servicios
                .Include(x => x.AsignacionServicio)
                .ThenInclude(x => x.Empleado)
                .ThenInclude(x => x.Asignacion)
                .ThenInclude(x => x.TipoEmpleado)
                .ToListAsync();

                return mapper.Map<List<ServicioListaDTO>>(servicio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServicioListaDTO>> GetServicio(int id)
        {
            try
            {
                var existe = await context.Servicios.AnyAsync(x => x.Id == id);

                if (!existe)
                {
                    return NotFound("No existe un registro con ese ID");
                }

                var servicio = await context.Servicios
                    .Include(x => x.AsignacionServicio)
                    .ThenInclude(x => x.Empleado)
                    .ThenInclude(x => x.Asignacion)
                    .ThenInclude(x => x.TipoEmpleado)
                    .FirstOrDefaultAsync(x => x.Id == id);

                return mapper.Map<ServicioListaDTO>(servicio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }        
        }

        [HttpPost]
        public async Task<ActionResult> Post(ServicioCreacionDTO servicioCreacionDTO)
        {
            try
            {
                var existe = await context.Servicios.AnyAsync(x => x.NombreServicio == servicioCreacionDTO.NombreServicio);

                if (existe)
                {
                    return BadRequest("El servicio ya se encuentra registrado");
                }
                var servicio = mapper.Map<Servicio>(servicioCreacionDTO);

                context.Add(servicio);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }         
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(ServicioCreacionDTO servicioCreacionDTO, int id)
        {
            try
            {
                var existe = await context.Servicios.AnyAsync(x => x.Id == id);

                if (!existe)
                {
                    return NotFound();
                }

                var servicio = mapper.Map<Servicio>(servicioCreacionDTO);

                if (servicio.Id != id)
                {
                    return BadRequest("La ID no coincide con ningun servicio registrado");
                }

                context.Update(servicio);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Servicio>> Delete(int id)
        {
            try
            {
                var servicio = await context.Servicios.FirstOrDefaultAsync(x => x.Id == id);

                if (servicio == null)
                {
                    return NotFound("La Id no corresponde a ningun registro");
                }

                context.Servicios.Remove(servicio);
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