using SpacecapsCase.Infrastructure.Data.Interfaces;

namespace SpacecapsCase.Application.Interfaces
{
    public interface ITarefaService<TEntity, TEntityId> : IAdd<TEntity>, IEdit<TEntity>, IDelete<TEntityId>, IQuery<TEntity, TEntityId>
    {
    }
}
