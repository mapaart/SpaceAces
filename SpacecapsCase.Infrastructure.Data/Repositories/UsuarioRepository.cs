using SpacecapsCase.Infrastructure.Data.Context;
using SpacecapsCase.Infrastructure.Data.Entity;
using SpacecapsCase.Infrastructure.Data.Interfaces.Repositories;

namespace SpacecapsCase.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : IBaseRepository<UsuarioEntity, int>
    {
        private DatabaseContext db;

        public UsuarioRepository(DatabaseContext _db)
        {
            this.db = _db;
        }

        public UsuarioEntity Add(UsuarioEntity entity)
        {
            db.Usuarios.Add(entity);
            return entity;
        }

        public void Delete(int entityId)
        {
            var usuarioSelecionado = db.Usuarios.Where(c => c.Id == entityId).FirstOrDefault();
            if (usuarioSelecionado != null)
            {
                db.Usuarios.Remove(usuarioSelecionado);
            }
        }

        public void Edit(UsuarioEntity entity)
        {
            var usuarioSelecionado = db.Usuarios.Where(c => c.Id == entity.Id).FirstOrDefault();
            if (usuarioSelecionado != null)
            {
                usuarioSelecionado.Nome = entity.Nome;
                usuarioSelecionado.Email = entity.Email;
                usuarioSelecionado.Senha = entity.Senha;
                db.Entry(usuarioSelecionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public List<UsuarioEntity> GetAll()
        {
            return db.Usuarios.ToList();
        }

        public UsuarioEntity GetById(int entityId)
        {
            return db.Usuarios.Where(c => c.Id == entityId).FirstOrDefault();
        }

        public UsuarioEntity GetByName(string name)
        {
            return db.Usuarios.FirstOrDefault(c => c.Nome == name);
        }


        public void SaveAll()
        {
            db.SaveChanges();
        }
    }
}