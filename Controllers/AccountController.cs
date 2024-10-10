using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using shap.Models;
using System.Security.Claims;

namespace shap.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signIn;

        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signIn)
        {
            userManager = _userManager;
            signIn = _signIn;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel UserVm)
        {
            ApplicationUser applicationUser = new ApplicationUser();
            if (ModelState.IsValid)
            {
                applicationUser.Email = UserVm.Email;
                applicationUser.UserName = UserVm.UserName;
                applicationUser.PasswordHash = UserVm.Password;

                IdentityResult result = await userManager.CreateAsync(applicationUser, UserVm.Password);
                if (result.Succeeded)
                {
                    signIn.SignInAsync(applicationUser, false);
                    return RedirectToAction("Index", "Department");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(UserVm);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userModel = await userManager.FindByNameAsync(userVM.UserName);
                if (userModel != null)
                {
                    bool found = await userManager.CheckPasswordAsync(userModel, userVM.Password);
                    if (found)
                    {

                        await signIn.SignInAsync(userModel, userVM.RememberMe);
                        return RedirectToAction("Index", "Department");
                    }
                }

                ModelState.AddModelError("", "Name & password Not Correct");
            }

            return View(userVM);
        }

        public async Task<IActionResult> signout()
        {
            await signIn.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
