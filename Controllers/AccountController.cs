using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementSystem.Models;
using BankManagementSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BankManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> signInManager;
        const string SessionName = "_Name";
        const string SessionAge = "_Age";
        const string SessionKeyDate = "_Date";
        public AccountController(UserManager<Users> userManager,
            SignInManager<Users> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Copy data from RegisterViewModel to IdentityUser
                var user = new Users
                {
                    UserName = model.Email,
                    Email = model.Email,
                    full_name = model.full_name
                };

                // Store user data in AspNetUsers database table
                var result = await userManager.CreateAsync(user, model.Password);

                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    TempData["status"] = $"-'{user.Email}' successfully added";
                   

                    return RedirectToAction("index", "main");
                }

                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            
            return RedirectToAction("index", "main");
        }

        [HttpGet]
        public IActionResult Login()
        {
            
          

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    HttpContext.Session.SetString(SessionName, model.Email);
                    HttpContext.Session.SetInt32(SessionAge, 20);
                    HttpContext.Session.Set<DateTime>(SessionKeyDate, DateTime.Now);
                    return RedirectToAction("index", "main");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }
    }
}



public static class SessionExtensions

{

    public static void Set<T>(this ISession session, string key, T value)

    {

        session.SetString(key, JsonConvert.SerializeObject(value));

    }

    public static T Get<T>(this ISession session, string key)

    {

        var value = session.GetString(key);

        return value == null ? default(T) :

        JsonConvert.DeserializeObject<T>(value);

    }

}