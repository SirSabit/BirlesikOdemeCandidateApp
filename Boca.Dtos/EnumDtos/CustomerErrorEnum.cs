using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Dtos.EnumDtos
{
    public enum CustomerErrorEnum
    {
        [Description("Customer not found")]
        E404,
        [Description("Tckn not verified")]
        E304,
        [Description("Customer added before")]
        E409
    }
}
