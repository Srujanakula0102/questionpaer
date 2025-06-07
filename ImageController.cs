//using CloudinaryDotNet;
//using CloudinaryDotNet.Actions;
//using Day1Csharp.Models;
//using Microsoft.AspNetCore.Mvc;
//using Questionweb.Controllers.data;

//namespace Questionweb.Controllers
//{
//    public class ImageController : Controller
//    {
//        private readonly Cloudinary _cloudinary;

//        private readonly ApplicationDbContext _context;
//        public ImageController(Cloudinary cloudinary, ApplicationDbContext context)
//        {
//            _cloudinary = cloudinary;
//            _context = context;
//        }

//        [HttpGet]
//        public IActionResult Uploads()
//        {
//            return View();
//        }
//        [HttpPost]
//        public async Task<IActionResult> Uploads(ImagesUploadModel model)
//        {
//            //string imageUrl = null;

//            if (model.File != null && model.File.Length > 0)
//            {
//                using (var stream = model.File.OpenReadStream())
//                {
//                    var uploadParams = new ImageUploadParams
//                    {
//                        File = new FileDescription(model.File.FileName, stream),
//                        PublicId = "my_uploaded_image_" + Guid.NewGuid()
//                    };

//                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);

//                    if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
//                    {
//                        var imageUrl = uploadResult.SecureUrl.ToString();
//                        ViewBag.ImageUrl = imageUrl;
//                        //Saving the info for the database
//                        var uploadedImg = new Uploadedimg
//                        {
//                            Publicid = uploadResult.PublicId,
//                            Url = imageUrl

//                        };
//                        _context.Uploads.Add(uploadedImg);
//                        await _context.SaveChangesAsync();

//                    }
//                    else
//                    {
//                        ModelState.AddModelError("", "Image upload failed");
//                    }
//                }
//            }

//            // Pass image URL to the view
//            return View();
//        }
//    }

//    }