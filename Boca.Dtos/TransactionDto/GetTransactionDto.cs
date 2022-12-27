using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Dtos.TransactionDto
{
    public class GetTransactionDto
    {
        public string TransactionId { get; set; }
        public string CustomerId { get; set; }
        public string OrderId { get; set; }
        public int TypeId { get; set; }
        public decimal Amount { get; set; }
        public string CardPan { get; set; }
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}
