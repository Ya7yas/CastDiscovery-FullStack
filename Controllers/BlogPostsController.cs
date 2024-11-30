using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using ScenePro.Models;
using ScenePro.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace ScenePro.Controllers
{
    public class BlogPostsController : Controller
    {
        private readonly AppDbContext _context;

        public BlogPostsController(AppDbContext context)
        {
            _context = context;
        }

       
        public IActionResult Create()
        {
            return View();
        }

        // POST: BlogPosts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogPost model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    if (model.ImageFile != null && model.ImageFile.Length > 0)
                    {
                        var imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                        if (!Directory.Exists(imagesFolder))
                        {
                            Directory.CreateDirectory(imagesFolder);
                        }

                        var fileName = Path.GetFileName(model.ImageFile.FileName);
                        var filePath = Path.Combine(imagesFolder, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await model.ImageFile.CopyToAsync(stream);
                        }

                        model.PostImage = fileName;
                    }

                  
                    model.IsVerified = false;

              
                    model.BlogPostId = Guid.NewGuid().ToString();

                    _context.BlogPosts.Add(model);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Wrong Adding Image: " + ex.Message);
                }
            }

            return View(model);
        }

        // GET: BlogPosts
        public IActionResult Index()
        {
            var posts = _context.BlogPosts.ToList();
            return View(posts);
        }

        // GET: BlogPosts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        // POST: BlogPosts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, BlogPost model)
        {
            if (id != model.BlogPostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // تحميل الصورة إذا تم تعديلها
                    if (model.ImageFile != null && model.ImageFile.Length > 0)
                    {
                        var imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                        if (!Directory.Exists(imagesFolder))
                        {
                            Directory.CreateDirectory(imagesFolder);
                        }

                        var fileName = Path.GetFileName(model.ImageFile.FileName);
                        var filePath = Path.Combine(imagesFolder, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await model.ImageFile.CopyToAsync(stream);
                        }

                        model.PostImage = fileName;
                    }

                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Wrong Editing Post " + ex.Message);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: BlogPosts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        // POST: BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);
            _context.BlogPosts.Remove(blogPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
