using Microsoft.AspNetCore.Authorization;
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
    //Requires Administrator Role
    [Authorize(Policy = "Admin Only")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var DBUsers = _context.Users;

            return View(DBUsers);
        }

        //Get all user profiles
        [HttpGet]
        public IEnumerable<ApplicationUser> Get()
        {
            return _context.ApplicationUser;
        }

        [HttpGet]
        public IActionResult Get(string id)
        {
            var result = _context.ApplicationUser.FirstOrDefault(h => h.Id == id);
            return Ok(result);
        }


        [HttpGet]
        //Delete a user profile
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var result = _context.ApplicationUser.FirstOrDefault(d => d.Id == id);
            if (result != null)
            {
                //Remove selected Id and all associated data
                _context.ApplicationUser.Remove(result);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Admin");
            }
            return BadRequest();

        }
    }
}
