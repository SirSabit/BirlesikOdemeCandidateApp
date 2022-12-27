using Boca.Core.BaseRepositories.Concrete;
using Boca.Dal.DbContexts;
using Boca.Dal.Repositories.TransactionRepository.Abstract;
using Boca.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Dal.Repositories.TransactionRepository.Concrete
{
    public class TransactionRepository : BaseRepository<TransactionEntity, MsSqlDbContext>, ITransactionRepository
    {
        private readonly MsSqlDbContext context;

        public TransactionRepository(MsSqlDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
