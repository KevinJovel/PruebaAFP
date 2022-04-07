using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaAFP.Models
{
    public class ClinicaContext : DbContext
    {
        public ClinicaContext(DbContextOptions<ClinicaContext> options) : base(options)
        {

        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }
        public DbSet<DetalleCita> detalleCitas { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DetalleCita>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CitaID);
                entity.Property(e => e.PacienteID);
                entity.Property(e => e.MedicoID);
                entity.Property(e => e.NombreMedico);
                entity.Property(e => e.TipoMedico);
                entity.Property(e => e.FechaHora);
                entity.Property(e => e.NombrePaciente);

            });
        }
    }
}
