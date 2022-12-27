using Boca.Core.BaseRepositories.Abstract;
using Boca.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Dal.Repositories.CustomerRepository.Abstract
{
    public interface ICustomerRepository : IBaseRepository<CustomerEntity>
    {
    }
}
