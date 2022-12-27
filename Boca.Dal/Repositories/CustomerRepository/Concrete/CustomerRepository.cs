using Boca.Core.BaseRepositories.Concrete;
using Boca.Dal.DbContexts;
using Boca.Dal.Repositories.CustomerRepository.Abstract;
using Boca.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Dal.Repositories.CustomerRepository.Concrete
{
    public class CustomerRepository : BaseRepository<CustomerEntity, MsSqlDbContext>, ICustomerRepository
    {
        private readonly MsSqlDbContext context;

        public CustomerRepository(MsSqlDbContext context) :base(context)
        {
            this.context = context;
        }
    }
}
