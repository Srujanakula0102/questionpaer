using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Questionweb.Constants;
using Questionweb.Controllers.data;
using Questionweb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionweb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Rolesfield.Role_Admin)]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Show both unapproved and approved papers
        [HttpGet]
        
        public async Task<IActionResult> Index()
        {
            var pendingPapers = await _context.QuestionPapers
                .Where(q => !q.IsApproved)
                .ToListAsync();
           
            var approvedPapers = await _context.QuestionPapers
                .Where(q => q.IsApproved)
                .ToListAsync();

            var feedbacks = await _context.Feedbacks.ToListAsync();

            var viewModel = new AdminIndexViewModel
            {
                UnapprovedPapers = pendingPapers,
                ApprovedPapers = approvedPapers,
                Feedbacks = feedbacks
            };

            return View(viewModel);
        }

        // Approve a Paper
        [HttpPost]
        public async Task<IActionResult> Approve(int id)
        {
            var paper = await _context.QuestionPapers.FindAsync(id);
            if (paper != null)
            {
                paper.IsApproved = true;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Reject(int id)
        {   
            var questionPaper = await _context.QuestionPapers.FindAsync(id);
            if (questionPaper == null)
            {
                return NotFound();
            }

            // Remove rejected paper from the database
            _context.QuestionPapers.Remove(questionPaper);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        // GET: Admin/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var questionPaper = _context.QuestionPapers.Find(id);
            if (questionPaper == null)
            {
                return NotFound();
            }
            return View(questionPaper);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            var obj = _context.QuestionPapers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _context.QuestionPapers.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

