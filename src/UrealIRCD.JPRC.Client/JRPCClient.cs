using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UrealIRCD.JPRC.Client.Api;
using UrealIRCD.JPRC.Client.Model;

namespace UrealIRCD.JPRC.Client
{
    public class JRPCClient
    {
       public JRPCClient(HttpClient httpClient,JRPCClientOption option)
       {
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{option.ApiUser}:{option.Password}"));
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);
            ChannelApi = new ChannelApi(httpClient, option);
            UserApi = new UserApi(httpClient, option);
            ServerApi = new ServerApi(httpClient, option);
            SpamApi = new SpamApi(httpClient, option);
       }

       public ChannelApi ChannelApi { get; private set; }

       public UserApi UserApi { get; private set; }

       public ServerApi ServerApi { get; private set; }

       public SpamApi SpamApi { get; private set; }

    }

}
