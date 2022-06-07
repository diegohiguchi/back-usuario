using Confitec.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Infrastructure.Persistence.Configurations
{
    public class EscolaridadeConfigurations : IEntityTypeConfiguration<Escolaridade>
    {
        public void Configure(EntityTypeBuilder<Escolaridade> builder)
        {
            builder
                .HasKey(p => p.Id);
        }
    }
}
