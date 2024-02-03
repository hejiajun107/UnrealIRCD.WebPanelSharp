using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UrealIRCD.JPRC.Client.Util;

namespace UrealIRCD.JPRC.Client.Model
{
    public class BanAndInviteBase
    {
        public string Name { get; set; }

        public string SetBy { get; set; }

        public DateTime SetAt { get; set; }

        public BanAction Type { get; set; }

        public string Reason { get; set; }

        public DateTime? ExpireAt { get; set; }
    }

    public class Ban : BanAndInviteBase
    {

    }

    public class Invite : BanAndInviteBase
    {

    }

    public enum BanAction
    {
        [Display(Name = "Kline")]
        [EnumKey(Name = "kline")]
        KLINE,
        [Display(Name = "Zline")]
        [EnumKey(Name = "zline")]
        ZLINE,
        [Display(Name = "Gline")]
        [EnumKey(Name = "gline")]
        GLINE,
        [Display(Name = "GZline")]
        [EnumKey(Name = "gzline")]
        GZLINE,
        [Display(Name = "Shun")]
        [EnumKey(Name = "shun")]
        SHUN,
        [Display(Name = "Kill")]
        [EnumKey(Name = "kill")]
        KILL
    }
}
