using Microsoft.EntityFrameworkCore;
using ClinicaBackend.Models;

namespace ClinicaBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Esto le dice a .NET: "Crea una tabla llamada Pacientes basada en mi clase Paciente"
        public DbSet<Paciente> Pacientes { get; set; }
    }
}