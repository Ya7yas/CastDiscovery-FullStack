using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScenePro.Data;
using ScenePro.Models;
using ScenePro.Models.ViewModel;

namespace ScenePro.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class TalentsController : Controller
    {
        private readonly AppDbContext _context;
      
        public TalentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Administrator/Talents
        public async Task<IActionResult> Index()
        {
            
            var talents = await _context.Talents.ToListAsync();

          
            ViewBag.PendingTalents = talents.Where(o => o.TStatus == TalentStatus.Pending).ToList();
            ViewBag.AcceptedTalents = talents.Where(o => o.TStatus == TalentStatus.Accepted).ToList();
            ViewBag.RejectedTalents = talents.Where(o => o.TStatus == TalentStatus.Rejected).ToList();

            return View();
        }

        public async Task<IActionResult> Pend(int id)
        {
            var talent = await _context.Talents.FindAsync(id);
            if (talent == null)
            {
                return NotFound();
            }

            talent.TStatus = TalentStatus.Pending;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Accept(int id)
        {
            var talent = await _context.Talents.FindAsync(id);
            if (talent == null)
            {
                return NotFound(); 
            }

            talent.TStatus = TalentStatus.Accepted; 
            await _context.SaveChangesAsync(); 

            return RedirectToAction(nameof(Index)); 
        }

        public async Task<IActionResult> Reject(int id)
        {
            var talent = await _context.Talents.FindAsync(id);
            if (talent == null)
            {
                return NotFound(); 
            }

            talent.TStatus = TalentStatus.Rejected; 
            await _context.SaveChangesAsync(); 

            return RedirectToAction(nameof(Index)); 
        }
        public ActionResult Details(int id)
        {
            var talent = _context.Talents.Find(id);
            if (talent == null)
            {
                return NotFound();
            }
            return View(talent);
        }
    }
}