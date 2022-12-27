using Boca.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Dal.DbContexts
{
    public class MsSqlDbContext :  DbContext
    {
        private readonly IConfiguration configuration;

        public MsSqlDbContext(DbContextOptions<MsSqlDbContext> options,IConfiguration configuration) :base(options)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MsSqlConStr"));
        }

        public DbSet<CustomerEntity> Customer { get; set; }
        public DbSet<TransactionEntity> Transaction { get; set; }
    }
}
