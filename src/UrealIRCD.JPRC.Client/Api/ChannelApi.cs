using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrealIRCD.JPRC.Client.Model;

namespace UrealIRCD.JPRC.Client.Api
{
    public class ChannelApi : ApiBase
    {
        public ChannelApi(HttpClient httpClient, JRPCClientOption option) : base(httpClient, option)
        {
        }

        public async Task<List<Channel>> List()
        {
            var result = await CallApi<JRPCList<Channel>>("channel.list");
            return result.Result?.List ?? new List<Channel>();
        }

        public async Task<ChannelDetail> Get(string name)
        {
            var result = await CallApi<ChannelDetail>("channel.get", new { Channel = "#" + name });
            return result.Result;
        }

        public async Task SetTopic(string channel,string topic)
        {
            await CallApi<object>("channel.set_topic", new { Channel = $"#{channel}", Topic = topic  });
        }

        public async Task Kick(string channel, string nick,string reason)
        {
            await CallApi<object>("channel.kick", new { Channel = $"#{channel}", Nick = nick, Reason = reason });
        }
    }
}
