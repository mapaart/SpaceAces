using SpacecapsCase.Application.Interfaces;
using SpacecapsCase.Infrastructure.Data.Entity;
using SpacecapsCase.Infrastructure.Data.Interfaces.Repositories;

namespace SpacecapsCase.Application.Services
{
    public class TarefaService : ITarefaService<TarefaEntity, int>
    {
        private readonly IBaseRepository<TarefaEntity, int> tarefaRepository;

        public TarefaService(IBaseRepository<TarefaEntity, int> _tarefaRepository)
        {
            tarefaRepository = _tarefaRepository;
        }

        public TarefaEntity Add(TarefaEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException("A tarefa precisa ser preenchida.");

            var result = tarefaRepository.Add(entity);
            tarefaRepository.SaveAll();
            return result;
        }

        public void Delete(int entityId)
        {
            if (entityId == null)
                throw new ArgumentNullException("O ID da tarefa precisa ser informado.");
            
            tarefaRepository.Delete(entityId);
            tarefaRepository.SaveAll();
        }

        public void Edit(TarefaEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException("A tarefa precisa ser preenchida.");

            tarefaRepository.Edit(entity);
            tarefaRepository.SaveAll();
        }

        public List<TarefaEntity> GetAll()
        {
            return tarefaRepository.GetAll();
        }

        public TarefaEntity GetById(int entityId)
        {
            return tarefaRepository.GetById(entityId);
        }

        public TarefaEntity GetByName(string name)
        {
            return tarefaRepository.GetByName(name);
        }
    }
}
