using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacecapsCase.Infrastructure.Data.Interfaces.Repositories
{
    public interface ITransaction
    {
        void SaveAll();
    }
}
