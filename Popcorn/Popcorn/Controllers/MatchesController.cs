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

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var currentUserMatches = _popcornContext.Matches.Where(p => p.UserMatchedId == currentUser.Id);
            List<ApplicationUser> matchedUsers = new List<ApplicationUser>();
            foreach (var match in currentUserMatches)
            {
                var isMatch = _popcornContext.Matches.Where(j => j.UserMatchedId == match.UserMatchingId && j.UserMatchingId == currentUser.Id);
                if (isMatch != null)
                {
                    var matchedUser = _context.ApplicationUser.Where(m => m.Id == isMatch.First().UserMatchedId);
                    matchedUsers.Add(matchedUser.First());
                }
            }
            return View(matchedUsers);
        }
    }
}
