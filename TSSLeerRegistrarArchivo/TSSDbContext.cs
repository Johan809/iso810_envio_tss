using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TSSLeerRegistrarArchivo.Model;

namespace TSSLeerRegistrarArchivo
{
    public class TSSDbContext : DbContext
    {
        public DbSet<AutodeterminacionTSS> Autodeterminaciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            string? connectionString = configuration.GetConnectionString("TSSDatabase");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AutodeterminacionTSS>(entity =>
            {
                entity.ToTable("Autodeterminacion_TSS");

                entity.HasKey(e => e.IdRegistro);
                entity.Property(e => e.RncEmpresa).HasMaxLength(11).IsRequired();
                entity.Property(e => e.PeriodoCotizable).HasMaxLength(7).IsRequired();
                entity.Property(e => e.Nss).HasMaxLength(12).IsRequired();
                entity.Property(e => e.Cedula).HasMaxLength(9).IsRequired();
                entity.Property(e => e.Nombres).HasMaxLength(30).IsRequired();
                entity.Property(e => e.Apellidos).HasMaxLength(30).IsRequired();
                entity.Property(e => e.TipoContrato).HasMaxLength(1).IsRequired();
                entity.Property(e => e.Estado).HasMaxLength(1).IsRequired();
            });
        }
    }
}
