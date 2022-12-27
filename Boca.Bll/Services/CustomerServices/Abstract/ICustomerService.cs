using Boca.Dtos.Customer;
using Boca.Dtos.Kps;
using Boca.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Bll.Services.CustomerServices.Abstract
{
    public interface ICustomerService
    {
        BaseResponseDto InsertCustomer(InsertCustomerDto dto);
        BaseResponseWithDataDto<GetCustomerDto> GetCustomerByTc(long tcNo);

        BaseResponseDto VerifyTckn(VerifyTcknDto dto);
    }
}
