using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Dtos.Kps
{
    public class VerifyTcknDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public long Tckn { get; set; }
        public int BirthYear { get; set; }
    }
}
