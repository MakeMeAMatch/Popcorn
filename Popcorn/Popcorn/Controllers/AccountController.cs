﻿using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        //Constructor that passes in usermanager and signInManager on page load
        public AccountController(UserManager<User> usermanager, SignInManager<User> signInManager)
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
                var user = new User { UserName = rvm.Email, FirstName = rvm.FirstName, LastName = rvm.LastName, FullName = rvm.FirstName + " " + rvm.LastName, KidAgeRanges = rvm.KidAgeRanges, NumberOfKids = rvm.NumberOfKids, CityState= rvm.CityState, DateOfBirth = rvm.DateOfBirth, PlaySpots = rvm.PlaySpots };
                var result = await _userManager.CreateAsync(user, rvm.Password);

                //if user was successfully registered
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
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
                    return RedirectToAction("Index", "Home");
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

        public async Task<IActionResult> ExternalLoginCallback(string returnURL=null, string remoteError=null)
        {
            if (remoteError != null) { return RedirectToAction(nameof(Login)); }

            var info = await _signInManager.GetExternalLoginInfoAsync();

            if(info == null) { return RedirectToAction(nameof(Login)); }

            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            if(result.IsLockedOut) { return RedirectToAction("Index", "Home"); } else { var email = info.Principal.FindFirstValue(ClaimTypes.Email);

                return View("ExternalLogin", new ExternalLoginModel { Email = email });
            }
                       
        }

        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginModel elm)
        {
            if (ModelState.IsValid) { var info = await _signInManager.GetExternalLoginInfoAsync();

                if (info == null) { return RedirectToAction(nameof(Login)); }

                var user = new User { UserName = elm.Email, Email = elm.Email };

                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded) { result = await _userManager.AddLoginAsync(user, info);

                if (result.Succeeded) { await _signInManager.SignInAsync(user, isPersistent: false); }

                    return RedirectToAction("Index", "Home");
                }

            }
            return View(nameof(ExternalLogin), elm);
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