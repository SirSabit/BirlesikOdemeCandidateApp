using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Dal.Connected_Services.ExternalApiCalls.Payzee.Abstract
{
    public interface ILogin
    {
        Task<string> PayzeeToken();
    }
}
