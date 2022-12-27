using Boca.Bll.Services.TransactionServices.Abstract;
using Boca.Dtos.Payzee.Pay;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Boca.Api.Controllers
{
    [Route("transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        /// <summary>
        /// Elimde Düzgün bir request olmadığı için bütün requesti olduğu gibi dto olarak taşıdım. Ayrıca api keyi de requeste ekledim. gerekli parametreleri girdiğinizde başarılı request atacaktır.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Pay(PayRequestDto request)
        {
            var result = transactionService.Pay(request);

            return StatusCode(result.StatusCode, result);
        }
        /// <summary>
        /// Tüm Transactionları getirir
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetTransactions()
        {
            var result = transactionService.GetTransactions();

            return StatusCode(result.StatusCode, result);
        }
    }
}
