using Microsoft.EntityFrameworkCore;
using ProjetoFinaAPIRest.Models;

namespace ProjetoFinaAPIRest.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<LocalEvento> LocalEvento { get; set; }
        public DbSet<TipoIngresso> TipoIngresso { get; set; }
        public DbSet<Ingresso> Ingresso { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost; initial Catalog=ProjetoFinalRestAPI; User ID=usuario;password=senha;language=Portuguese;Trusted_Connection=True");
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Evento>()
            .HasOne(e => e.LocalEvento)
            .WithMany(e => e.Eventos)
            .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
