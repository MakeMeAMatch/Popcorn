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
    //[Authorize(Policy = "Admin Only")]
    public class AdminController : Controller
    {
        private readonly PopcornDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(PopcornDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Get all user profiles
        [HttpGet]
        public IEnumerable<Profiles> Get()
        {
            return _context.Profiles;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _context.Profiles.FirstOrDefault(h => h.Id == id);
            return Ok(result);
        }

        //Delete a user profile
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _context.Profiles.FirstOrDefault(d => d.Id == id);
            if (result != null)
            {
                //Remove selected Id and all associated data
                _context.Profiles.Remove(result);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();

        }
    }
}
