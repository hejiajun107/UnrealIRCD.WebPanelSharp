using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using UrealIRCD.JPRC.Client.Model;
using UrealIRCD.JPRC.Client.Util;
using static System.Collections.Specialized.BitVector32;
using SpamMatchType = UrealIRCD.JPRC.Client.Model.SpamMatchType;

namespace UrealIRCD.JPRC.Client.Api
{
    public class SpamApi : ApiBase
    {
        public SpamApi(HttpClient httpClient, JRPCClientOption option) : base(httpClient, option)
        {
        }

        public async Task<List<SpamFilter>> List()
        {
            var result = await CallApi<JRPCList<SpamFilter>>("spamfilter.list");
            return result.Result?.List ?? new List<SpamFilter>();
        }

        public async Task<SpamFilter> Get(string name)
        {
            var result = await CallApi<SpamFilter>("spamfilter.get", new { name = name });
            return result.Result;
        }

        ///<summary>
        ///c channel Channel message
        ///p private Private message(from user->user)
        ///n private-notice Private notice
        ///N channel-notice Channel notice
        ///P part Part reason
        ///q quit Quit reason
        ///d dcc DCC filename
        ///a away Away message
        ///t topic Setting a topic
        ///T message-tag Ban Message tags sent by the client.This will be matched against name= value or just name if there is no value
        ///u user User ban, will be matched against nick!user @host:realname
        ///R raw Match a raw command / IRC protocol line (except message tags), eg LIST*
        /// </summary>
        /// <param name="name"></param>
        /// <param name="matchType"></param>
        /// <param name="reason"></param>
        /// <param name="banDuration"></param>
        /// <returns></returns>
        public async Task Add(string name, SpamMatchType matchType,BanAction action,string reason,int banDuration)
        {
            await CallApi<object>("spamfilter.add", new { Name = name, MatchType = matchType.GetKey(), BanAction = action.GetKey(), SpamfilterTargets = "cpnNPqu", Reason = reason, BanDuration = banDuration });
        }

        public async Task Delete(string name, BanAction action, SpamMatchType matchType)
        {
            await CallApi<object>("spamfilter.del", new { Name = name, MatchType = matchType.GetKey(), BanAction = action.GetKey(), SpamfilterTargets = "cpnNPqu" });
        }
    }
}
