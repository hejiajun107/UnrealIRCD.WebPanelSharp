using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UrealIRCD.JPRC.Client.Model;

namespace UrealIRCD.JPRC.Client.Api
{
    public class UserApi : ApiBase
    {
        public UserApi(HttpClient httpClient, JRPCClientOption option) : base(httpClient, option)
        {
        }

        public async Task<List<UserClient>> List()
        {
            var result = await CallApi<JRPCList<UserClient>>("user.list");
            return result.Result?.List ?? new List<UserClient>();
        }

        public async Task<UserClient> Get(string idOrName)
        {
            var result = await CallApi<UserDetail>("user.get", new { Nick = idOrName });
            return result.Result.Client;
        }

        public async Task SetNick(string nick,string newnick)
        {
            await CallApi<object>("user.set_nick", new { Nick = nick, Newnick = newnick });
        }

        public async Task SetUsername(string nick, string username)
        {
            await CallApi<object>("user.set_username", new { Nick = nick, Username = username });
        }

        public async Task SetRealname(string nick, string realname)
        {
            await CallApi<object>("user.set_realname", new { Nick = nick, Username = realname });
        }

        public async Task Kill(string nickOrId, string reason)
        {
            await CallApi<object>("user.kill", new { Nick = nickOrId, Reason = reason });
        }
        /// <summary>
        /// There is also user.kill. The difference is that user.kill will show that the user is forcefully killed, while user.quit pretend the user quit normally. This slight difference may invoke certain client behavior. For example, some clients don't immediately reconnect for a KILL but do so on a QUIT.
        /// </summary>
        /// <param name="nickOrId"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public async Task Quit(string nickOrId, string reason)
        {
            await CallApi<object>("user.quit", new { Nick = nickOrId, Reason = reason });
        }

        public async Task<List<UserClient>> WhoWasName(string nickname)
        {
            var result = await CallApi<JRPCList<UserClient>>("whowas.get", new { Nick = nickname });
            return result.Result?.List ?? new List<UserClient>();
        }

        public async Task<List<UserClient>> WhoWasIP(string ip)
        {
            var result = await CallApi<JRPCList<UserClient>>("whowas.get", new { Ip = ip });
            return result.Result?.List ?? new List<UserClient>();
        }
    }
}
