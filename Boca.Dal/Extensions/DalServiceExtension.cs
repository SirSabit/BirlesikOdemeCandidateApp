using Boca.Dal.Connected_Services.ExternalApiCalls.Payzee.Abstract;
using Boca.Dal.Connected_Services.ExternalApiCalls.Payzee.Concrete;
using Boca.Dal.DbContexts;
using Boca.Dal.Repositories.CustomerRepository.Abstract;
using Boca.Dal.Repositories.CustomerRepository.Concrete;
using Boca.Dal.Repositories.KpsRepository.Abstract;
using Boca.Dal.Repositories.KpsRepository.Concrete;
using Boca.Dal.Repositories.TransactionRepository.Abstract;
using Boca.Dal.Repositories.TransactionRepository.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Dal.Extensions
{
    public static class DalServiceExtension
    {
        public static void InsertDalExtensions(this IServiceCollection services)
        {
            services.AddDbContext<MsSqlDbContext>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IKpsRepository, KpsRepository>();
            services.AddScoped<ILogin, Login>();
            services.AddScoped<IPayment, Payment>();
        }
    }
}
