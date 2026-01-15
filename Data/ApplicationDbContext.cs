using Microsoft.EntityFrameworkCore;
using SCE_DB_NET.Models;

namespace SCE_DB_NET.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }

        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración explícita de claves, relaciones, etc.
            modelBuilder.Entity<Empresa>()
                .HasKey(e => e.IdEmpresa);

            base.OnModelCreating(modelBuilder);
        }
    }
}
