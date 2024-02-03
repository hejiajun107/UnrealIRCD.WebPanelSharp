using System.IO;
using UrealIRCD.JPRC.Client.Model;

namespace UnrealIRCD.WebPanelSharp.Models
{
    public class SpamRule
    {
        public string Name { get; set; }

        public string Reason { get; set; }

        public SpamMatchType MatchType { get; set; }

        public BanAction Type { get; set; }
    }
}
