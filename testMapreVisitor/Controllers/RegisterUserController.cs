using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using testMapreVisitor.Models;
using testMapreVisitor.ViewModel;

namespace testMapreVisitor.Controllers
{
   
    public class RegisterUserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager; 
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Register Model { get; set; }

        public RegisterUserController(UserManager<IdentityUser> userManager, 
                                      SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser()
        {       

            if (!ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = Model.Email,
                    Email = Model.Email,
                };

                var result = await userManager.CreateAsync(user, Model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return Redirect("~/Home/Index");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            };

            return View();
        }

    }
}
