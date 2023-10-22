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
    public class disastersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public disastersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: disasters
        public async Task<IActionResult> Index()
        {
              return _context.disaster != null ? 
                          View(await _context.disaster.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.disaster'  is null.");
        }

        // GET: disasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.disaster == null)
            {
                return NotFound();
            }

            var disaster = await _context.disaster
                .FirstOrDefaultAsync(m => m.Disaster_ID == id);
            if (disaster == null)
            {
                return NotFound();
            }

            // Load MoneyAllocations for the Disaster using a LINQ query
            var moneyAllocations = await _context.Allocation_Money
                .Where(a => a.Disaster_id == id)
                .ToListAsync();

            ViewData["Allocate_Money"] = moneyAllocations;

            var goodsAllocations = await _context.Allocation_Goods
        .Where(a => a.Disaster_ID == id)
        .ToListAsync();

            ViewData["Allocate_Goods"] = goodsAllocations;

           

            return View(disaster);
        }

        // GET: disasters/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: disasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Disaster_ID,StartDate,EndDate,Location,Description,RequireAid")] disaster disaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disaster);
        }

        // GET: disasters/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.disaster == null)
            {
                return NotFound();
            }

            var disaster = await _context.disaster.FindAsync(id);
            if (disaster == null)
            {
                return NotFound();
            }
            return View(disaster);
        }

        // POST: disasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Disaster_ID,StartDate,EndDate,Location,Description,RequireAid")] disaster disaster)
        {
            if (id != disaster.Disaster_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!disasterExists(disaster.Disaster_ID))
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
            return View(disaster);
        }

        // GET: disasters/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.disaster == null)
            {
                return NotFound();
            }

            var disaster = await _context.disaster
                .FirstOrDefaultAsync(m => m.Disaster_ID == id);
            if (disaster == null)
            {
                return NotFound();
            }

            return View(disaster);
        }

        // POST: disasters/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.disaster == null)
            {
                return Problem("Entity set 'ApplicationDbContext.disaster'  is null.");
            }
            var disaster = await _context.disaster.FindAsync(id);
            if (disaster != null)
            {
                _context.disaster.Remove(disaster);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool disasterExists(int id)
        {
          return (_context.disaster?.Any(e => e.Disaster_ID == id)).GetValueOrDefault();
        }
    }
}
