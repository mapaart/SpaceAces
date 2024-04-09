using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SpacecapsCase.Infrastructure.Data.Entity;

namespace SpacecapsCase.Infrastructure.Data.Configs
{
    public class TarefaConfig : IEntityTypeConfiguration<TarefaEntity>
    {
        public TarefaConfig() { }

        public void Configure(EntityTypeBuilder<TarefaEntity> builder)
        {
            builder.ToTable("tarefa");
            builder.HasKey(c => c.Id);
        }
    }
}
