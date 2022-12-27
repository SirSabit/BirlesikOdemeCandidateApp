using Boca.Dal.Connected_Services.ExternalApiCalls.Payzee.Abstract;
using Boca.Dtos.Payzee.Login;
using Boca.Dtos.Payzee.Pay;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Dal.Connected_Services.ExternalApiCalls.Payzee.Concrete
{
    public class Payment : IPayment
    {
        string url = "https://ppgpayment-test.birlesikodeme.com:20000/api/ppg/Payment/NoneSecurePayment";

        public async Task<dynamic> Pay(PayRequestDto payRequest,string token)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(url);

                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",token);

                    var jsonData = JsonConvert.SerializeObject(payRequest);

                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    var result = await client.PostAsync(url, content);
                    string resultContent = await result.Content.ReadAsStringAsync();

                    dynamic obj = JsonConvert.DeserializeObject(resultContent);

                    return obj; 
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
