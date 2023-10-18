using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Disaster_Allievation_Foundation_.Data;
using Disaster_Allievation_Foundation_.Models;
using Microsoft.AspNetCore.Authorization;

namespace Disaster_Allievation_Foundation_.Controllers
{
    public class monetary_donationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public monetary_donationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: monetary_donations
        public async Task<IActionResult> Index()
        {
              return _context.monetary_donations != null ? 
                          View(await _context.monetary_donations.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.monetary_donations'  is null.");
        }

        // GET: monetary_donations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.monetary_donations == null)
            {
                return NotFound();
            }

            var monetary_donations = await _context.monetary_donations
                .FirstOrDefaultAsync(m => m.Monetary_ID == id);
            if (monetary_donations == null)
            {
                return NotFound();
            }

            return View(monetary_donations);
        }

        // GET: monetary_donations/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: monetary_donations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Monetary_ID,Donor,Date,Amount")] monetary_donations monetary_donations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monetary_donations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monetary_donations);
        }

        // GET: monetary_donations/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.monetary_donations == null)
            {
                return NotFound();
            }

            var monetary_donations = await _context.monetary_donations.FindAsync(id);
            if (monetary_donations == null)
            {
                return NotFound();
            }
            return View(monetary_donations);
        }

        // POST: monetary_donations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Monetary_ID,Donor,Date,Amount")] monetary_donations monetary_donations)
        {
            if (id != monetary_donations.Monetary_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monetary_donations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!monetary_donationsExists(monetary_donations.Monetary_ID))
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
            return View(monetary_donations);
        }

        // GET: monetary_donations/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.monetary_donations == null)
            {
                return NotFound();
            }

            var monetary_donations = await _context.monetary_donations
                .FirstOrDefaultAsync(m => m.Monetary_ID == id);
            if (monetary_donations == null)
            {
                return NotFound();
            }

            return View(monetary_donations);
        }

        // POST: monetary_donations/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.monetary_donations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.monetary_donations'  is null.");
            }
            var monetary_donations = await _context.monetary_donations.FindAsync(id);
            if (monetary_donations != null)
            {
                _context.monetary_donations.Remove(monetary_donations);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool monetary_donationsExists(int id)
        {
          return (_context.monetary_donations?.Any(e => e.Monetary_ID == id)).GetValueOrDefault();
        }
    }
}
