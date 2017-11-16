using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //GET
        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Profiles);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> TakeQuiz(Profiles profiles)
        {
            //var DbProfiles = _context.Profiles;
            //var currentUser = await _userManager.GetUserAsync(User);
            //var currentUserId = _context.Profiles.Where(w => w.ApplicationUserId == currentUser.Id);
            List<Answers> answerList = _context.Answers.ToList();
            ViewBag.Answers = answerList;
            ViewBag.UserQuestions = _context.Questions;
            ViewBag.UserAnswers = _context.Answers;

            await _context.AddAsync(profiles);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");           

        }

        //PUT
        [HttpPut]
        public async Task<IActionResult> Put(int id, Profiles profiles)
        {
            if(!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            var check = _context.Profiles.FirstOrDefault(w => w.Id == id);

            if (check != null)
            {
                check.ApplicationUserId = profiles.ApplicationUserId;
                check.AnswersId = profiles.AnswersId;
                check.QuestionsId = profiles.QuestionsId;
                check.ResponsesId = profiles.ResponsesId;
                _context.Update(check);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Index", new { id = profiles.Id }, profiles);
            }
            else if(check == null)
            {
                await TakeQuiz(profiles);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _context.Profiles.FirstOrDefault(w => w.Id == id);

            if(result != null)
            {
                _context.Profiles.Remove(result);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}
