using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreFitness.Models;
using CoreFitness.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreFitness.Controllers
{
    public class AccountController : Controller
    {


        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;


        public AccountController(UserManager<User> userManager,
                                 SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        

        // Display user registration form 
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }


        // Register a new user 
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if(ModelState.IsValid)
            {
                var user = new User { Name = model.Name, Surname = model.Surname,
                    UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user,model.Password);

                if (result.Succeeded)
                {
                    if (signInManager.IsSignedIn(User) && User.IsInRole("admin"))
                    {
                        return RedirectToAction("ListAllUsers", "Admin");
                    }

                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                // Loop through errors and display them in the view
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        // Display user registration form 
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }



        // Check if the provided email is in use
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use.");
            }
        }
        // Register a new user 
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, 
                    model.RememberMe, false
                    );

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    else
                    {
                        return RedirectToAction("index", "home");
                    }

                }

                // Display errors 
                ModelState.AddModelError(string.Empty, "invalid login");
                
            }

            return View(model);
        }


        // Log out the user 
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
        
        // Display Access Denied View
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}