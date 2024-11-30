using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScenePro.Data;
using ScenePro.Models;

namespace ScenePro.Controllers
{
    public class TalentsController : Controller
    {
        private readonly AppDbContext _context;

        public TalentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Talents
        public async Task<IActionResult> Index()
        {
            var talents = _context.Talents
          .Where(o => o.TStatus == TalentStatus.Accepted)
          .ToList();

            return View(talents);
        }

        // GET: TalentPortfolios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var talent = _context.Talents.Find(id);

            if (talent == null)
            {
                return NotFound();
            }

            if (talent.TStatus == TalentStatus.Accepted)
            {
                return View(talent);
            }
            else if (talent.TStatus == TalentStatus.Pending)
            {
                return RedirectToAction("PendingMessage");
            }
            else if (talent.TStatus == TalentStatus.Rejected)
            {
                return RedirectToAction("RejectedMessage");
            }

            return View(talent);
        }

        // GET: Talents/Create
        public IActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
               
                TempData["LoginRequired"] = "You need to log in to join us.";
                return RedirectToAction("Login", "Account"); 
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Talent talent)
        {
            if (ModelState.IsValid)
            {
                if (talent.ImageFile != null && talent.ImageFile.Length > 0)
                {
                   
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                    var fileName = Path.GetFileName(talent.ImageFile.FileName);
                    var filePath = Path.Combine(uploadsFolder, fileName);

                   
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await talent.ImageFile.CopyToAsync(fileStream);
                    }

                        talent.ProfilePicture = $"/images/{fileName}";

                   
                    _context.Talents.Add(talent);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }

                return BadRequest(new { message = "No file uploaded." });
            }

            return View(talent);
        }


        // GET: Talents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talent = await _context.Talents.FindAsync(id);
            if (talent == null)
            {
                return NotFound();
            }
            return View(talent);
        }

        
        [HttpPost]
      
        public async Task<IActionResult> Edit(int id, Talent talent)
        {
            if (id != talent.TalentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(talent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TalentExists(talent.TalentId))
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
            return View(talent);
        }

        // GET: Talents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talent = await _context.Talents
                .FirstOrDefaultAsync(m => m.TalentId == id);
            if (talent == null)
            {
                return NotFound();
            }

            return View(talent);
        }

        // POST: Talents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var talent = await _context.Talents.FindAsync(id);
            if (talent != null)
            {
                _context.Talents.Remove(talent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TalentExists(int id)
        {
            return _context.Talents.Any(e => e.TalentId == id);
        }
    }
}
