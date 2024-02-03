using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrealIRCD.JPRC.Client.Util;

namespace UrealIRCD.JPRC.Client.Model
{
    public class SpamFilter
    {
        public string Name { get; set; }

        public SpamMatchType MatchType { get; set; }

        public BanAction BanAction { get; set; }

        public string SetBy { get; set; }

        public DateTime SetAt { get; set; }

        public string Reason { get; set; }



    }

    public enum SpamMatchType
    {
        [EnumKey(Name = "simple")]
        Simple,
        [EnumKey(Name = "regex")]
        Regex,
    }
}
