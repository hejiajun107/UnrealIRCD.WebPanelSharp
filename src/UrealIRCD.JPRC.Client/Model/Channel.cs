using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrealIRCD.JPRC.Client.Model
{

    public class Channel
    {
        #region basic
        public string Name { get; set; }

        public DateTime CreationTime { get; set; }

        public int NumUsers { get; set; }

        public string Modes { get; set; }
        #endregion

        public List<Ban> Bans { get; set; }
        public List<Ban> BanExemptions { get; set; }
        public List<Invite> InviteExceptions { get; set; }
        public List<UserClient> Members { get; set; }

    }

    public class ChannelDetail 
    {
        public Channel Channel { get; set; }
    }
}
