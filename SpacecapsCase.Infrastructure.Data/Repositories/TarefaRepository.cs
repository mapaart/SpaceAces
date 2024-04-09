using SpacecapsCase.Infrastructure.Data.Context;
using SpacecapsCase.Infrastructure.Data.Entity;
using SpacecapsCase.Infrastructure.Data.Interfaces.Repositories;

namespace SpacecapsCase.Infrastructure.Data.Repositories
{
    public class TarefaRepository : IBaseRepository<TarefaEntity, int>
    {
        private DatabaseContext db;

        public TarefaRepository(DatabaseContext _db)
        {
            this.db = _db;
        }

        public TarefaEntity Add(TarefaEntity entity)
        {
            db.Tarefas.Add(entity);
            return entity;
        }

        public void Delete(int entityId)
        {
            var tarefaSelecionada = db.Tarefas.Where(c => c.Id == entityId).FirstOrDefault();
            if (tarefaSelecionada != null)
            {
                db.Tarefas.Remove(tarefaSelecionada);
            }
        }

        public void Edit(TarefaEntity entity)
        {
            var tarefaSelecionada = db.Tarefas.Where(c => c.Id == entity.Id).FirstOrDefault();
            if (tarefaSelecionada != null)
            {
                tarefaSelecionada.Descricao = entity.Descricao;
                tarefaSelecionada.Status = entity.Status;
                tarefaSelecionada.DataAtualizacao = DateTime.Now;
                db.Entry(tarefaSelecionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public List<TarefaEntity> GetAll()
        {
            return db.Tarefas.ToList();
        }

        public TarefaEntity GetById(int entityId)
        {
            return db.Tarefas.Where(c => c.Id == entityId).FirstOrDefault();
        }

        public TarefaEntity GetByName(string descricao)
        {
            return db.Tarefas.Where(c => c.Descricao == descricao).FirstOrDefault();
        }

        public void SaveAll()
        {
            db.SaveChanges();
        }
    }
}