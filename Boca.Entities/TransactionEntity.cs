using Boca.Core.BaseEntities;
using Boca.Core.BaseEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Entities
{
    public class TransactionEntity : BaseEntity
    {
        public string TransactionId { get; set; }
        public string CustomerId { get; set; }
        public string OrderId { get; set; }
        public TypeIdEnum TypeId { get; set; }
        public decimal Amount { get; set; }
        public string CardPan { get; set; }
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        
    }
}
