using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;
using UnrealIRCD.WebPanelSharp.Data.Entity;

namespace UnrealIRCD.WebPanelSharp
{
    public class SysUserClaimsPrincipalFactory<TUser> : UserClaimsPrincipalFactory<SysUser>
    {
        public SysUserClaimsPrincipalFactory(UserManager<SysUser> userManager, IOptions<IdentityOptions> optionsAccessor)
      : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(SysUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            // Add your custom claim logic here if needed
            return identity;
        }
    }
}
