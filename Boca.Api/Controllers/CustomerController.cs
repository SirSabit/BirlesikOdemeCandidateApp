using Boca.Bll.Services.CustomerServices.Abstract;
using Boca.Bll.Services.CustomerServices.Concrete;
using Boca.Dtos.Customer;
using Boca.Dtos.Kps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Boca.Api.Controllers
{
    [Route("customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        /// <summary>
        /// Customer ekle
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertCustomer(InsertCustomerDto dto)
        {
            var result = customerService.InsertCustomer(dto);
            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// TcNo'ya Göre Customer Getir
        /// </summary>
        /// <param name="tcNo"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCustomer(long tcNo)
        {
            var data = customerService.GetCustomerByTc(tcNo);
            return Ok(data);
        }
        /// <summary>
        /// Tc No doğrula ve Customer'ı güncelle
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("verify")]
        public IActionResult VerifyTckn(VerifyTcknDto dto)
        {
            var result = customerService.VerifyTckn(dto);

            return StatusCode(result.StatusCode, result);
        }
    }
}
