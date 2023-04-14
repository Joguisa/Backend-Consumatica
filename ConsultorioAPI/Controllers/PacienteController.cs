using ConsultorioAPI.DTO.EmpleadoDTOs;
using ConsultorioAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioAPI.Controllers
{
    [ApiController]
    [Route("api/pacientes")]
    public class PacienteController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PacienteController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Paciente>>> Get()
        {
            try
            {
                return await context.Pacientes.ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{cedula}")]
        public async Task<ActionResult<Paciente>> Get([FromRoute] string cedula)
        {
            try
            {
                var paciente = await context.Pacientes.FirstOrDefaultAsync(x => x.Cedula == cedula);

                if (paciente == null)
                {
                    return NotFound();
                }

                return paciente;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Paciente paciente)
        {
            try
            {
                var existe = await context.Pacientes.AnyAsync(x => x.Cedula == paciente.Cedula);
                bool cedulaNum = int.TryParse(paciente.Cedula, out _);

                if (existe)
                {
                    return BadRequest("El paciente ya se encuentra registrado");
                }

                if (cedulaNum == false || paciente.Cedula.Length < 10)
                {
                    return BadRequest("El formato de la cedula es incorrecto");
                }

                context.Add(paciente);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Paciente paciente, int id)
        {
            try
            {
                var existe = await context.Pacientes.AnyAsync(x => x.Id == id);
                bool cedulaNum = int.TryParse(paciente.Cedula, out _);

                if (!existe)
                {
                    return NotFound("No existe ningun registro");
                }

                if (paciente.Id != id)
                {
                    return BadRequest("La ID no coincide con ningun paciente");
                }

                if (cedulaNum == false || paciente.Cedula.Length < 10)
                {
                    return BadRequest("El formato de la cedula es incorrecto");
                }

                context.Update(paciente);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{cedula}")]
        public async Task<ActionResult<Paciente>> Delete([FromRoute] string cedula)
        {
            try
            {
                var paciente = await context.Pacientes.FirstOrDefaultAsync(x => x.Cedula == cedula);

                if (paciente == null)
                {
                    return NotFound();
                }

                context.Pacientes.Remove(paciente);
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

