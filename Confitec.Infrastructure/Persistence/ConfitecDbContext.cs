using Confitec.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Confitec.Infrastructure.Persistence
{
    public class ConfitecDbContext : DbContext
    {
        public ConfitecDbContext(DbContextOptions<ConfitecDbContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Escolaridade> Escolaridades { get; set; }
        public DbSet<HistoricoEscolar> HistoricosEscolar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Escolaridade>().HasData(
                new Escolaridade
                {
                    Id = 1,
                    Descricao = "Infantil"
                },
                new Escolaridade
                {
                    Id = 2,
                    Descricao = "Fundamental"
                },
                new Escolaridade
                {
                    Id = 3,
                    Descricao = "Médio"
                },
                new Escolaridade
                {
                    Id = 4,
                    Descricao = "Superior"
                }
            );

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
