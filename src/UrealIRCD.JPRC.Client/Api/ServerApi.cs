using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UrealIRCD.JPRC.Client.Model;
using UrealIRCD.JPRC.Client.Util;

namespace UrealIRCD.JPRC.Client.Api
{
    public class ServerApi : ApiBase
    {
        public ServerApi(HttpClient httpClient, JRPCClientOption option) : base(httpClient, option)
        {
        }

        #region Ban

        public async Task<List<Ban>> BanList()
        {
            var result = await CallApi<JRPCList<Ban>>("server_ban.list");
            return result.Result?.List ?? new List<Ban>();
        }

        public async Task<object> BanGet(string name)
        {
            var result = await CallApi<object>("server_ban.get", new { Channel = "#" + name });
            return result.Result;
        }

        public async Task BanAdd(string name,BanAction banAction, DateTime expireAt,string reason)
        {
            await CallApi<object>("server_ban.add", new { Type = banAction.GetKey(), Name = name, ExpireAt = expireAt, Reason = reason });
        }

        public async Task BanDelete(string name,BanAction banAction )
        {
            await CallApi<object>("server_ban.del", new { Type = banAction.GetKey(), Name = name });
        }
        #endregion




    }
}
