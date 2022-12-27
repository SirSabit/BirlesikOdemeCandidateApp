using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Dtos.Customer
{
    public class GetCustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public long  IdentityNo { get; set; }
        public bool  IdentityVerified { get; set; }
        public DateTime BirhDate { get; set; }
    }
}
