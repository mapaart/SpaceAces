using SpacecapsCase.Infrastructure.Data.Entity;
using SpacecapsCase.Infrastructure.Data.Interfaces;


namespace SpacecapsCase.Application.Interfaces
{
    public interface IUsuarioService<TEntity, TEntityId> : IAdd<TEntity>, IQuery<TEntity, TEntityId>
    {
        UsuarioEntity Add(UsuarioEntity entity);
        List<UsuarioEntity> GetAll();
        UsuarioEntity GetById(TEntityId entityId);
        UsuarioEntity GetByName(string name);
    }
}
