using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace UnrealIRCD.WebPanelSharp.Data.Entity
{
    public class SysUser
    {
        public long Id { get; set; }

        [StringLength(120,ErrorMessage = "Account is too long")]
        public string Name { get; set; }

        public string Password { get; set; }

    }
}
