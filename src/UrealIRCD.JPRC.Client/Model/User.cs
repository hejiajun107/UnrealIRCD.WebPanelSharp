using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrealIRCD.JPRC.Client.Model
{
    public class UserDetail
    {
        public UserClient Client { get; set; }
    }

    public class UserClient
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Hostname { get; set; }
        public string Ip { get; set; }

        public DateTime ConnectedSince { get; set; }

        public DateTime IdleSince { get; set; }
        public string Details { get; set; }

        public UserInfo User { get; set; }

        public string Event { get; set; }

    }

    public class UserInfo
    {
        public string Username { get; set; }

        public string Realname { get; set; }

        public int Reputation { get; set; }

        public List<string> SecurityGroups { get; set; }

        public List<Channel> Channels { get; set; }

    }
}
