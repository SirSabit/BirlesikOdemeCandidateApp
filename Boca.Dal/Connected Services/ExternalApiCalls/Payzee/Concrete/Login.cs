using Boca.Dal.Connected_Services.ExternalApiCalls.Payzee.Abstract;
using Boca.Dtos.Payzee.Login;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Boca.Dal.Connected_Services.ExternalApiCalls.Payzee.Concrete
{
    public class Login : ILogin
    {
        public async Task<string> PayzeeToken()
        {
            var url = "https://ppgsecurity-test.birlesikodeme.com:55002/api/ppg/Securities/authenticationMerchant";

            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(url);

                    LoginRequestDto loginRequest = new LoginRequestDto();
                    var jsonData = JsonConvert.SerializeObject(loginRequest);

                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    var result = await client.PostAsync(url, content);
                    string resultContent = await result.Content.ReadAsStringAsync();

                    dynamic tokenobj = JsonConvert.DeserializeObject(resultContent);

                    if (tokenobj.responseCode != "00")
                        throw new Exception($"Login Error: {tokenobj.responseMessage}");

                    return tokenobj.result.token;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        }

    }
}
