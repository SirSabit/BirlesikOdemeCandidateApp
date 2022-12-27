using Boca.Dtos.Payzee.Pay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Dal.Connected_Services.ExternalApiCalls.Payzee.Abstract
{
    public interface IPayment
    {
        Task<dynamic> Pay(PayRequestDto payRequest, string token);
    }
}
