using Boca.Dal.Repositories.KpsRepository.Abstract;
using KPSPublic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Dal.Repositories.KpsRepository.Concrete
{
    public class KpsRepository : IKpsRepository
    {

        public bool CheckTckn(long tckn, string name, string surname, int birthYear)
        {
            try
            {
                var client = new KPSPublic.KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);

                return client.TCKimlikNoDogrula(tckn, name, surname, birthYear);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
