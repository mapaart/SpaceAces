using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SpacecapsCase.Infrastructure.Data.Entity;

namespace SpacecapsCase.Infrastructure.Data.Configs
{
    public class NivelConfig : IEntityTypeConfiguration<NivelEntity>
    {
        public NivelConfig() { }
        public void Configure(EntityTypeBuilder<NivelEntity> builder)
        {
            builder.ToTable("nivel_user");
            builder.HasKey(n => n.Id);
        }
    }
}
