using Boca.Dtos.Payzee.Pay;
using Boca.Dtos.ResponseDtos;
using Boca.Dtos.TransactionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Bll.Services.TransactionServices.Abstract
{
    public interface ITransactionService
    {
        BaseResponseDto Pay(PayRequestDto dto);

        BaseResponseWithDataDto<List<GetTransactionDto>> GetTransactions();
    }
}
