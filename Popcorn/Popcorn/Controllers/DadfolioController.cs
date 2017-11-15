using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Popcorn.Data;
using Popcorn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        //public async Task<IActionResult> TakeQuiz()
        //{
        //    Dictionary<int, string> MyDictionary = new Dictionary<int, string>();
        //    Questions q = new Questions();

        //    var Db = Database.Open("DefaultConnection");

        //    var DbProfiles = _context.Profiles;
        //    var currentUser = await _userManager.GetUserAsync(User);
        //    MyDictionary = _context.Profiles.Where(w => w.Id == currentUser.Id);
        //        select



        //}
    }
}
