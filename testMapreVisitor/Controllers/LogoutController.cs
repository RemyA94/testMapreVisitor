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
            await signInManager.SignOutAsync();
            return Redirect("~/Login/Login");
        }

        [HttpPost]
        public IActionResult DontLogoutUser()
        {
            return Redirect("~/Home/Index");
        }
    }
}
