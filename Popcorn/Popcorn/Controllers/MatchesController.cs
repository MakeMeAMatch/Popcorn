using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Popcorn.Data;
using Popcorn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Popcorn.Controllers
{
    public class MatchesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly PopcornDbContext _popcornContext;

        public MatchesController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, PopcornDbContext popcornContext)
        {
            _userManager = userManager;
            _context = context;
            _popcornContext = popcornContext;
        }

        public async Task<IActionResult> Index()
        {
            // Get currently logged in User
            var currentUser = await _userManager.GetUserAsync(User);
            // Get any Matches where the currentUser was "liked"
            var currentUserMatches = _popcornContext.Matches.Where(p => p.UserMatchedId == currentUser.Id);
            // Initialize a list of User objects to hold any matched Users
            List<ApplicationUser> matchedUsers = new List<ApplicationUser>();
            // Get any User that the current User has "liked" and has been "liked" by
            foreach (var match in currentUserMatches)
            {
                // Get any Matches where the Current User "liked" Users who have "liked" them already
                var isMatch = _popcornContext.Matches.Where(j => j.UserMatchedId == match.UserMatchingId && j.UserMatchingId == currentUser.Id);
                if (isMatch.ToList().Count() > 0)
                {
                    var item = isMatch.First().UserMatchedId;
                    // Get any User from the context where the User's Id 
                    var matchedUser = _context.ApplicationUser.Where(m => m.Id == item);
                    
                    matchedUsers.Add(matchedUser.First()); 
                    
                }
            }
            return View(matchedUsers);
        }
    }
}
