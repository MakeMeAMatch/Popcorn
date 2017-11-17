using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Popcorn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Popcorn.Controllers
{
    //Inheriting from Controller
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        //Constructor that passes in usermanager and signInManager on page load
        public AccountController(UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = usermanager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //Creating a new user
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm, string returnUrl = null)
        {

            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = rvm.Email, FirstName = rvm.FirstName, LastName = rvm.LastName, FullName = rvm.FirstName + " " + rvm.LastName, KidAgeRanges = rvm.KidAgeRanges, NumberOfKids = rvm.NumberOfKids, CityState = rvm.CityState, DateOfBirth = rvm.DateOfBirth, PlaySpots = rvm.PlaySpots };
                var result = await _userManager.CreateAsync(user, rvm.Password);


                //if user was successfully registered
                if (result.Succeeded)
                {
                    //if user registers with admin e-mail, then give them administrator role
                    if (rvm.Email == "admin@codefellows.com")
                    {
                        //Create a list where my claims will be added to
                        List<Claim> myClaims = new List<Claim>();

                        // claim for the User's role
                        Claim claim1 = new Claim(ClaimTypes.Role, "Administrator", ClaimValueTypes.String);
                        myClaims.Add(claim1);

                        var addClaims = await _userManager.AddClaimsAsync(user, myClaims);

                        if (addClaims.Succeeded)
                        {
                            await _signInManager.PasswordSignInAsync(rvm.Email, rvm.Password, true, lockoutOnFailure: false);

                            return RedirectToAction("Index", "Admin");
                        }
                    }
                    else
                    {
                        return RedirectToAction("Login", "Account");
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //Login user and redirect to home page
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(lvm.Email);

                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, lvm.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (lvm.Email == "admin@codefellows.com")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        var userIdentity = new ClaimsIdentity("Dad");
                        var userPrincipal = new ClaimsPrincipal(userIdentity);

                        User.AddIdentity(userIdentity);

                        await HttpContext.SignInAsync(
                        "MyCookieLogin", userPrincipal,
                            new AuthenticationProperties
                            {
                                ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
                                IsPersistent = false,
                                AllowRefresh = false

                            });

                        return RedirectToAction("Index", "Home");
                    }
                }

            }
            string error = "Incorrect username or password";
            ModelState.AddModelError("", error);
            return View();
        }

        public IActionResult ExternalLogin(string provider, string returnURL = null)
        {
            var redirectURL = Url.Action(nameof(ExternalLoginCallback), "Account", new
            {
                returnURL
            });

            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectURL);

            return Challenge(properties, provider);
        }

        public async Task<IActionResult> ExternalLoginCallback(string returnURL = null, string remoteError = null)
        {
            if (remoteError != null) { return RedirectToAction(nameof(Login)); }

            var info = await _signInManager.GetExternalLoginInfoAsync();

            if (info == null) { return RedirectToAction(nameof(Login)); }

            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            if (result.IsLockedOut) { return RedirectToAction("Index", "Home"); }
            else
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);

                return View("ExternalLogin", new ExternalLoginModel { Email = email });
            }

        }

        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginModel elm)
        {
            if (ModelState.IsValid)
            {
                var info = await _signInManager.GetExternalLoginInfoAsync();

                if (info == null) { return RedirectToAction(nameof(Login)); }

                var user = new ApplicationUser { UserName = elm.Email, Email = elm.Email };

                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user, info);

                    if (result.Succeeded) { await _signInManager.SignInAsync(user, isPersistent: false); }

                    return RedirectToAction("Index", "Home");
                }

            }
            return View(nameof(ExternalLogin), elm);
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
