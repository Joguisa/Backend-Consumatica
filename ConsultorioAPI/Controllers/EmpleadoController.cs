using AutoMapper;
using ConsultorioAPI.DTO.EmpleadoDTOs;
using ConsultorioAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioAPI.Controllers
{
    [ApiController]
    [Route("api/empleados")]
    public class EmpleadoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public EmpleadoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmpleadoDTO>>> Get()
        {
            try
            {
                var empleados = await context.Empleados
                .Include(x => x.Asignacion)
                .ThenInclude(x => x.TipoEmpleado)
                .Include(x => x.Servicio)
                .ThenInclude(x => x.TipoServicio)
                .ToListAsync();
                return mapper.Map<List<EmpleadoDTO>>(empleados);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{cedula}")]
        public async Task<ActionResult<Empleado>> Get([FromRoute] string cedula)
        {
            try
            {
                var empleado = await context.Empleados.FirstOrDefaultAsync(x => x.Cedula == cedula);

                if (empleado == null)
                {
                    return NotFound();
                }

                return empleado;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(EmpleadoCreacionDTO empleadoCreacionDTO, int id_tipo_empleado, int id_servicio)
        {
            try
            {
                var existe = await context.Empleados.AnyAsync(x => x.Cedula == empleadoCreacionDTO.Cedula);
                bool cedulaNum = int.TryParse(empleadoCreacionDTO.Cedula, out _);

                if (existe)
                {
                    return BadRequest("El empleado ya se encuentra registrado");
                }

                if (cedulaNum == false || empleadoCreacionDTO.Cedula.Length < 10)
                {
                    return BadRequest("El formato de la cedula es incorrecto");
                }

                var empleado = mapper.Map<Empleado>(empleadoCreacionDTO);

                var rpta = context.Add(empleado);
                await context.SaveChangesAsync();

                context.AsignarEmpleado.Add(new() { EmpleadoId = empleado.Id, TipoEmpleadoId = id_tipo_empleado });
                context.AsignarServicio.Add(new() { EmpleadoId = empleado.Id, ServicioId = id_servicio });
                await context.SaveChangesAsync();

                return Ok();

                //context.Add(empleado);
                //await context.SaveChangesAsync();
                //return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(EmpleadoCreacionDTO empleadoCreacionDTO, int id)
        {
            try
            {
                var existe = await context.Empleados.AnyAsync(x => x.Id == id);
                bool cedulaNum = int.TryParse(empleadoCreacionDTO.Cedula, out _);

                if (!existe)
                {
                    return NotFound();
                }

                var empleado = mapper.Map<Empleado>(empleadoCreacionDTO);

                if (empleado.Id != id)
                {
                    return BadRequest("La ID no coincide con ningun empleado");
                }

                if (cedulaNum == false || empleadoCreacionDTO.Cedula.Length < 10)
                {
                    return BadRequest("El formato de la cedula es incorrecto");
                }

                context.Update(empleado);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{cedula}")]
        public async Task<ActionResult<Empleado>> Delete([FromRoute] string cedula)
        {
            try
            {
                var empleado = await context.Empleados.FirstOrDefaultAsync(x => x.Cedula == cedula);

                if (empleado == null)
                {
                    return NotFound();
                }

                context.Empleados.Remove(empleado);
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
