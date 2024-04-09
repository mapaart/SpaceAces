using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpacecapsCase.Infrastructure.Data.Entity;

namespace SpacecapsCase.Infrastructure.Data.Configs
{
    public class UsuarioConfig : IEntityTypeConfiguration<UsuarioEntity>
    {
        public UsuarioConfig() { }
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.ToTable("usuario");
            builder.HasKey(c => c.Id);

        }
    }
}
