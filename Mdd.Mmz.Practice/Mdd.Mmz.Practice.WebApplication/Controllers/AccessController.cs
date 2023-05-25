using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Mdd.Mmz.Practice.WebApplication.Models;
using Mdd.Mmz.Practice.Core;
using Microsoft.AspNetCore.Authorization;

namespace Mdd.Mmz.Practice.WebApplication.Controllers
{

    public class AccessController : Controller
    {

        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index1", "People");

            return View();
        }

        [HttpPost]
        
        public async Task<IActionResult> Login(VMLogin modelLogin)
        {   

            if (modelLogin.Email == "admin@example.com" && modelLogin.Password == "123")
            {
                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, modelLogin.Email),
                    new Claim(ClaimTypes.Role, "Admin")
                };               
                    
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = modelLogin.KeepLoggedIn
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);
                
                return RedirectToAction("Index1", "People");
            }
            else if (modelLogin.Email == "student@example.com" && modelLogin.Password == "1234")
            {
                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, modelLogin.Email),
                    new Claim(ClaimTypes.Role, "User")
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = modelLogin.KeepLoggedIn
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

                
                return RedirectToAction("Index1", "People");
            }



            ViewData["ValidateMessage"] = "user not found";
            return View();
        }

    }
}
