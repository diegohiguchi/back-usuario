using Confitec.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Infrastructure.Persistence.Configurations
{
    public class HistoricoEscolarConfigurations : IEntityTypeConfiguration<HistoricoEscolar>
    {
        public void Configure(EntityTypeBuilder<HistoricoEscolar> builder)
        {
            builder
                .HasKey(p => p.Id);
        }
    }
}
