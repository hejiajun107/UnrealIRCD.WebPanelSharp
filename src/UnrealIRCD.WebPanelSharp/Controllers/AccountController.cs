using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using UnrealIRCD.WebPanelSharp.Data.Entity;
using UnrealIRCD.WebPanelSharp.Models;
using System.Linq;
using System.Threading.Tasks;
using UnrealIRCD.WebPanelSharp.Data;

namespace UnrealIRCD.WebPanelSharp.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDataContext _dbContext;

        public AccountController(ApplicationDataContext dbContext) 
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> SignIn(string returnUrl = "/")
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> LogOut(string returnUrl = "/")
        {
            await HttpContext.SignOutAsync();
            return Redirect(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromForm]LoginForm loginModel)
        {
            var admin = _dbContext.Set<SysUser>().Where(x => x.Name == loginModel.Name).FirstOrDefault();

            if (admin is null || admin.Password != loginModel.Password)
            {
                ViewBag.Error = "登录失败";
                return View();
            }

            List<Claim> list = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
                        new Claim(ClaimTypes.Name, admin.Name)
                    };

            var claimsIdentity = new ClaimsIdentity(
                list, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {

            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            return Redirect(loginModel.ReturnUrl);
        }
    }
}
