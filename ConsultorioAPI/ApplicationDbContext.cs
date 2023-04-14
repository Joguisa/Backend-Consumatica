using ConsultorioAPI.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<TipoEmpleado> TipoEmpleados { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<AsignacionTipoEmpleado> AsignarEmpleado { get; set; }
        public DbSet<AsignacionTipoServicio> AsignarServicio { get; set; }
        public DbSet<AsignarTurno> AsignarTurno { get; set; }
    }
}
