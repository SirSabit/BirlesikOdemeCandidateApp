using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Dal.Repositories.KpsRepository.Abstract
{
    public interface IKpsRepository
    {
        bool CheckTckn(long tckn, string name, string surname, int birthYear);
    }
}
