using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using testMapreVisitor.Models;

namespace testMapreVisitor.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Login Model { get; set; }


        public LoginController(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser( string returnUrl = null)
        {
            if( ModelState.IsValid)
            {
                var identityResult = await signInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, false);
                if (identityResult.Succeeded)
                {
                    if(returnUrl == null || returnUrl == "/")
                    {
                        return Redirect("~/Home/Index");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
                ModelState.AddModelError("", "Username or Password incorrect");
            }
            return Redirect("~/Login/Login");
        }
    }
}
