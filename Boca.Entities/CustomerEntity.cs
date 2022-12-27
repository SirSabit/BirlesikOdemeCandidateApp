using Boca.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Entities
{
    public class CustomerEntity : BaseEntity
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public long IdentityNo { get; set; }
        public bool IdentityVerified { get; set; }
        
    }
}
