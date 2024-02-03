using System;
using UrealIRCD.JPRC.Client.Model;

namespace UnrealIRCD.WebPanelSharp.Models
{
    public class BanRule
    {
        public string Name { get; set; }

        public string Reason { get; set; }

        public DateTime? ExpiredAt { get; set; }

        public BanAction Type { get; set; }
    }
}
