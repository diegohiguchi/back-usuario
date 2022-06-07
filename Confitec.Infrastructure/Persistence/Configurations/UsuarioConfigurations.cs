using Confitec.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Infrastructure.Persistence.Configurations
{
    public class UsuarioConfigurations : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .HasOne(p => p.Escolaridade)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(p => p.EscolaridadeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.HistoricoEscolar)
                .WithOne(x => x.Usuario)
                .HasForeignKey<Usuario>(p => p.HistoricoEscolarId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
