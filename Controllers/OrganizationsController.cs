using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScenePro.Data;
using ScenePro.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ScenePro.Controllers
{
    public class OrganizationsController : Controller
    {
        private readonly AppDbContext _context;

        public OrganizationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Organizations
        public async Task<IActionResult> Index()
        {
            var organizations = _context.Organizations
            .Where(o => o.Status == OrganizationStatus.Accepted) 
            .ToList();

            return View(organizations);
        }

        // GET: Organizations/Details/5
        public IActionResult Details(int id)
        {
            var organization = _context.Organizations.Find(id);

            if (organization == null)
            {
                return NotFound();
            }

            if (organization.Status == OrganizationStatus.Accepted)
            {
                return View(organization);
            }
            else if (organization.Status == OrganizationStatus.Pending)
            {
                return RedirectToAction("PendingMessage");
            }
            else if (organization.Status == OrganizationStatus.Rejected)
            {
                return RedirectToAction("RejectedMessage");
            }

            return View(organization);
        }
        [Authorize]
        public IActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                
                TempData["LoginRequired"] = "You need to log in to join us.";
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        // POST: Organizations/Create
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Organization organization)
        {
            if (ModelState.IsValid)
            {
                if (organization.ImageFile != null && organization.ImageFile.Length > 0)
                {
                    try
                    {
                      
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                        var fileName = Path.GetFileName(organization.ImageFile.FileName);
                        var filePath = Path.Combine(uploadsFolder, fileName);

                       
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await organization.ImageFile.CopyToAsync(fileStream);
                        }

                       
                        organization.OrganizationImage = $"/images/{fileName}";

                      
                        _context.Add(organization);
                        await _context.SaveChangesAsync();

                        
                        TempData["PendingAlert"] = true;

                      
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                       
                        ModelState.AddModelError(string.Empty, "An error occurred while uploading the file.");
                    }
                }
                else
                {
                    ModelState.AddModelError("ImageFile", "Please upload a valid image file.");
                }
            }

           
            return View(organization);
        }


        // GET: Organizations/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var organization = await _context.Organizations.FindAsync(id);
            if (organization == null)
            {
                return NotFound();
            }
            return View(organization);
        }

        // POST: Organizations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Organization organization)
        {
            if (id != organization.OrganizationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organization);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizationExists(organization.OrganizationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(organization);
        }

        // GET: Organizations/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var organization = await _context.Organizations.FindAsync(id);
            if (organization == null)
            {
                return NotFound();
            }
            return View(organization);
        }

        // POST: Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organization = await _context.Organizations.FindAsync(id);
            if (organization != null)
            {
                _context.Organizations.Remove(organization);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizationExists(int id)
        {
            return _context.Organizations.Any(e => e.OrganizationId == id);
        }
    }
}



