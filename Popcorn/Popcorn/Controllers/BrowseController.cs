﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly UserManager<ApplicationUser> _userManager;
        //adding user manager in order to ID the current user
        private readonly ApplicationDbContext _context;

         public BrowseController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index(string filter)
        {
            List<ApplicationUser> UserProfiles = new List<ApplicationUser>();

            //add roles and claims here

            var DBUsers = _context.Users;
            var currentUserId = _userManager.GetUserId(User);
            var currentUser = _context.Users.Where(u => u.Id == currentUserId).First();

            IQueryable<ApplicationUser> results;

            if (!String.IsNullOrEmpty(filter))
            {
                if (filter == "CityState")
                {
                    results = DBUsers.Where(w => w.CityState == currentUser.CityState);
                }
                else if (filter == "PlaySpots")
                {
                    results = from w in DBUsers
                              where w.PlaySpots == currentUser.PlaySpots
                              select w;
                }
                else
                {
                    results = from w in DBUsers
                              where w.KidAgeRanges == currentUser.KidAgeRanges
                              select w;
                }
            }
            else
            {
                results = DBUsers;
            }
            return View(results);
        }

        //this action will affect which user profile results are displayed based on which quality is chosen by the user

        //[HttpGet("{id:int}")]
        public async Task<IActionResult> BeSelective(string quality, int id)
        {
            if (id > 0)
            {
                var DbUsers = _context.Users;
                
                var currentUser = await _userManager.GetUserAsync(User);

                IQueryable<ApplicationUser> results;

                // Demonstration of using both lambda and SQL Queries to get information we want from a larger data set
                if (quality == "CityState")
                {
                    results = DbUsers.Where(w => w.CityState == currentUser.CityState);
                }
                else if (quality == "PlaySpots")
                {
                    results = from w in DbUsers
                              where w.PlaySpots == currentUser.PlaySpots
                              select w;
                }
                else
                {
                    results = from w in DbUsers
                              where w.KidAgeRanges == currentUser.KidAgeRanges
                              select w;
                }
                
                return View(results);
                
            }

            //TODO: Update on behavior on what to do if id is less than 1
            return View();
        }

        public IActionResult DaddyLikes()
        {
            
            return View();
        }

        public IActionResult IsLiked()
        {
            return View();
        }
    }
}
