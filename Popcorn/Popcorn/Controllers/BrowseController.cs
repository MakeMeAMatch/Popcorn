using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Popcorn.Data;
using Popcorn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Popcorn.Controllers
{
    //[Route("[controller]")]
    public class BrowseController : Controller
    {
        //dependency injection
        private readonly UserManager<User> _userManager;
        //adding user manager in order to ID the current user
        private readonly ApplicationDbContext _context;

         public BrowseController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            List<User> UserProfiles = new List<User>();

            //add roles and claims here

            var DBUsers = _context.Users;

            foreach(var w in DBUsers)
            {
                UserProfiles.Add(w);
            }
            return View(UserProfiles);
        }

        //this action will affect which user profile results are displayed based on which quality is chosen by the user

        //[HttpGet("{id:int}")]
        public async Task<IActionResult> BeSelective(string quality, int id)
        {
            if (id > 0)
            {
                List<Users> UserProfiles = new List<Users>();

                var DbUsers = _context.Users;

                //var currentUser = await _userManager.FindByIdAsync(User.Identity.GetUserId);
                var currentUser = await _userManager.GetUserAsync(User);

                
                return View();
                
            }

            //TODO: Update on behavior on what to do if id is less than 1
            return View();




        }
    }
}
