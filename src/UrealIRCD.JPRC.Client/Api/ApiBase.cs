using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrealIRCD.JPRC.Client.Model;

namespace UrealIRCD.JPRC.Client.Api
{
    public class ApiBase
    {
        private JRPCClientOption _option;
        private HttpClient _httpClient;

        public ApiBase(HttpClient httpClient, JRPCClientOption option)
        {
            _httpClient = httpClient;
            _option = option;
        }

        protected async Task<JRPCResponse<TOut>> CallApi<TOut>(string method, object paras = null)
        {
            var setting = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy() { }
                }
            };

            setting.NullValueHandling = NullValueHandling.Ignore;

            var requestBody = new JRPCRequest()
            {
                Id = _option.ID,
                Method = method,
                Params = paras is null ? new object() : paras
            };

            var response = await _httpClient.PostAsync($"https://{_option.Host}/api", new StringContent(JsonConvert.SerializeObject(requestBody, setting)));
            response.EnsureSuccessStatusCode();
            var str = await response.Content.ReadAsStringAsync();
            //Console.Write(str);
            return JsonConvert.DeserializeObject<JRPCResponse<TOut>>(str, setting);
        }

    }
}
