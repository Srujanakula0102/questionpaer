using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Questionweb.Controllers.data;
using Questionweb.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Questionweb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Cloudinary _cloudinary;

        public HomeController(Cloudinary cloudinary, ApplicationDbContext context)
        {
            _context = context;
            _cloudinary = cloudinary;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vm = new HomeIndexViewModel
            {
                Feedback = new FeedbackViewModel()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(HomeIndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Save feedback to database
                _context.Feedbacks.Add(model.Feedback);
                _context.SaveChanges();
                TempData["Notification"] = "Thank you for your feedback!";
                return RedirectToAction("Index");
            }

            // Repopulate QuestionPapers for redisplay
            model.QuestionPapers = _context.QuestionPapers.Where(q => q.IsApproved).ToList();
            return View(model);
        }

        // Show upload page
        [HttpGet]
        public IActionResult Uploads()
        {
            return View();
        }

        // Handle file upload
        [HttpPost]
        public async Task<IActionResult> Uploads(IFormFile file, string name, string subject, int year, string group)
        {
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("", "Invalid file.");
                return View();
            }

            string imageUrl = await UploadImageToCloudinary(file);
            if (imageUrl == null)
            {
                ModelState.AddModelError("", "Image upload failed.");
                return View();
            }

            // Save question paper details
            var questionPaper = new QuestionPaper
            {
                UploaderName = name,
                Subject = subject,
                Year = year,
                Group = group,
                Url = imageUrl,
                IsApproved = false
            };

            _context.QuestionPapers.Add(questionPaper);
            await _context.SaveChangesAsync();
            TempData["success"] ="Uploaded Successfuly";
            return RedirectToAction("Index");
        }

        private async Task<string> UploadImageToCloudinary(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    PublicId = $"Srujan@@_{Guid.NewGuid()}"
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                return uploadResult.StatusCode == System.Net.HttpStatusCode.OK ? uploadResult.SecureUrl.ToString() : null;
            }
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        #region API CALLS

        [HttpGet]

        public IActionResult GetAll()
        {
            var approvedPapers = _context.QuestionPapers
                .Where(q => q.IsApproved)
                .ToList(); // Using synchronous call

            return Json(new { data = approvedPapers });
        }
        #endregion
    }
}
