using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace RetailPlatform.API.Controllers
{
    public class RetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ClaimsPrincipal SetClaims(string username, string name, string id, bool isCustomer, bool isVendor, string assignedRole)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("username", username));
            claims.Add(new Claim("roleName", "User"));
            claims.Add(new Claim("isCustomer", isCustomer.ToString()));
            claims.Add(new Claim("isVendor", isVendor.ToString()));
            claims.Add(new Claim("loggedUser", name));
            claims.Add(new Claim("userId", id));
            claims.Add(new Claim("assignedRole", assignedRole));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
            claims.Add(new Claim(ClaimTypes.Name, name));
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return claimsPrincipal;
        }
    }
}
