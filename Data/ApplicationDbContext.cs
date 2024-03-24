using Microsoft.EntityFrameworkCore;
using PrevisaoClima.Model;

namespace PrevisaoClima.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<DadosMeteorologicos> DadosMeteorologicos { get; set; }
        public DbSet<LogError> LogError { get; set; }
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DUTRA;Database=Teste-aec;User Id=sa;Password=123;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DadosMeteorologicos>(eb =>
            {
                eb.HasNoKey();
            });
        }
    }
}
