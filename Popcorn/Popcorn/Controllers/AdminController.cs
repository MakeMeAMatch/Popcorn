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
    [Authorize(Policy = "Admin Only")]
    public class AdminController : Controller
    {
        //dependency injection
        private readonly UserManager<Profiles> _userManager;
        //adding user manager in order to ID the current user
        private readonly PopcornDbContext _context;

        public AdminController(PopcornDbContext context, UserManager<Profiles> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Admin");
        }

        //Get all user profiles
        [HttpGet]
        public IEnumerable<Profiles> Get()
        {
            return _context.Users;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _context.Users.FirstOrDefault(h => h.Id == id);
            return Ok(result);
        }

        //Delete a user profile
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _context.Users.FirstOrDefault(d => d.Id == id);
            if (result != null)
            {
                //Remove selected Id and all associated data
                _context.Users.Remove(result);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();

        }
    }
}
