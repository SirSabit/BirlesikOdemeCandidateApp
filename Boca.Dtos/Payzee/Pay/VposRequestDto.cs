using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Dtos.Payzee.Pay
{
    public class VposRequestDto
    {
        public string UserCode { get; set; }
        public string Rnd { get; set; }
        public string TxnType { get; set; }
        public string TotalAmount { get; set; }
        public string CustomerId { get; set; }
        public string OrderId { get; set; }
        public string ApiKey { get; set; }
    }
}
