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
    public class OrganizationsController : Controller
    {
        private readonly AppDbContext _context;
       

        public OrganizationsController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var pendingOrganizations = _context.Organizations
                .Where(o => o.Status == OrganizationStatus.Pending)
                .ToList();

            var acceptedOrganizations = _context.Organizations
                .Where(o => o.Status == OrganizationStatus.Accepted)
                .ToList();

            var rejectedOrganizations = _context.Organizations
                .Where(o => o.Status == OrganizationStatus.Rejected)
                .ToList();

            ViewBag.PendingOrganizations = pendingOrganizations;
            ViewBag.AcceptedOrganizations = acceptedOrganizations;
            ViewBag.RejectedOrganizations = rejectedOrganizations;

            return View();
        }

        public async Task<IActionResult> Pend(int id)
        {
            var organization = await _context.Organizations.FindAsync(id);
            if (organization == null)
            {
                return NotFound();
            }

            organization.Status = OrganizationStatus.Pending;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Accept(int id)
                {
                    var organization = await _context.Organizations.FindAsync(id);
                    if (organization == null)
                    {
                        return NotFound();
                    }

                    organization.Status = OrganizationStatus.Accepted;
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }


                public ActionResult Reject(int id)
        {
            var organization = _context.Organizations.Find(id);
            if (organization != null)
            {
                organization.Status = OrganizationStatus.Rejected; 
                _context.SaveChanges();
            }
            return RedirectToAction("Index"); 
        }



        public ActionResult Details(int id)
        {
            var organization = _context.Organizations.Find(id);
            if (organization == null)
            {
                return NotFound();
            }
            return View(organization);
        }
       
    }
}

