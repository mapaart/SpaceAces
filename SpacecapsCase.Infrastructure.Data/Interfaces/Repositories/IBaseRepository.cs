using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacecapsCase.Infrastructure.Data.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, TEntityId> : IAdd<TEntity>, IEdit<TEntity>, IDelete<TEntityId>, IQuery<TEntity, TEntityId>, ITransaction
    {
    }
}
