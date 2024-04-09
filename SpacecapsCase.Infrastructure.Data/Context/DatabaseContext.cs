using Microsoft.EntityFrameworkCore;
using SpacecapsCase.Infrastructure.Data.Configs;
using SpacecapsCase.Infrastructure.Data.Entity;

namespace SpacecapsCase.Infrastructure.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<TarefaEntity> Tarefas { get; set; }  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=spacecaps;Uid=root;Pwd=root;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UsuarioConfig());
            builder.ApplyConfiguration(new TarefaConfig());
        }
    }
}
