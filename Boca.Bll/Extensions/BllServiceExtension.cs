using Boca.Bll.Services.CustomerServices.Abstract;
using Boca.Bll.Services.CustomerServices.Concrete;
using Boca.Bll.Services.TransactionServices.Abstract;
using Boca.Bll.Services.TransactionServices.Concrete;
using Boca.Dal.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Bll.Extensions
{
    public static class BllServiceExtension
    {
        public static void InsertBllExtensions(this IServiceCollection services)
        {
            services.InsertDalExtensions();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ITransactionService, TransactionService>();
        }
    }
}
