using System;

namespace UnrealIRCD.WebPanelSharp.Models
{
    public class BanActionPara
    {
        public string Reason { get; set; }

        public DateTime? ExpiredAt { get; set; }
    }
}
