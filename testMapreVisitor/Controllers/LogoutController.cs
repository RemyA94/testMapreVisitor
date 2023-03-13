using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;


namespace testMapreVisitor.Controllers
{
    public class LogoutController : Controller
    {

        private readonly SignInManager<IdentityUser> signInManager;

        public LogoutController(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public IActionResult Logout()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> LogoutUser()
        {
            HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
            await HttpContext.SignOutAsync();
            await signInManager.SignOutAsync();
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return Redirect("~/Login/Login");
        }

        [HttpPost]
        public IActionResult DontLogoutUser()
        {
            return Redirect("~/Home/Index");
        }
    }
}
