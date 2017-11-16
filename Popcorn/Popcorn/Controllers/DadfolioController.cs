using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Popcorn.Data;
using Popcorn.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Popcorn.Controllers
{
    public class DadfolioController : Controller
    {
        private readonly PopcornDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DadfolioController(PopcornDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TakeQuiz()
        {
            //Questions q = new Questions();

            //var DbProfiles = _context.Profiles;
            //var currentUser = await _userManager.GetUserAsync(User);
            //var currentUserId = _context.Profiles.Where(w => w.ApplicationUserId == currentUser.Id);
            ViewBag.UserQuestions = _context.Questions;
            ViewBag.UserAnswers = _context.Answers;

            return View();           

        }
    }
}
