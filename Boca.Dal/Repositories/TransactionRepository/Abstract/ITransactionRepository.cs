using Boca.Core.BaseRepositories.Abstract;
using Boca.Core.BaseRepositories.Concrete;
using Boca.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Dal.Repositories.TransactionRepository.Abstract
{
    public interface ITransactionRepository : IBaseRepository<TransactionEntity>
    {
    }
}
