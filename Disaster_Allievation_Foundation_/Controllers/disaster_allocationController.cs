using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Disaster_Allievation_Foundation_.Data;
using Disaster_Allievation_Foundation_.Models;

namespace Disaster_Allievation_Foundation_.Controllers
{
    public class disaster_allocationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public disaster_allocationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: disaster_allocation
        public async Task<IActionResult> Index()
        {
              return _context.disaster_allocation != null ? 
                          View(await _context.disaster_allocation.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.disaster_allocation'  is null.");
        }

        // GET: disaster_allocation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.disaster_allocation == null)
            {
                return NotFound();
            }

            var disaster_allocation = await _context.disaster_allocation
                .FirstOrDefaultAsync(m => m.Inventory_ID == id);
            if (disaster_allocation == null)
            {
                return NotFound();
            }

            return View(disaster_allocation);
        }

        // GET: disaster_allocation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: disaster_allocation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Inventory_ID,Allocate_Disaster,Allocate_Money,Purchase_Amount,Timestamp")] disaster_allocation disaster_allocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disaster_allocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disaster_allocation);
        }

        // GET: disaster_allocation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.disaster_allocation == null)
            {
                return NotFound();
            }

            var disaster_allocation = await _context.disaster_allocation.FindAsync(id);
            if (disaster_allocation == null)
            {
                return NotFound();
            }
            return View(disaster_allocation);
        }

        // POST: disaster_allocation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Inventory_ID,Allocate_Disaster,Allocate_Money,Purchase_Amount,Timestamp")] disaster_allocation disaster_allocation)
        {
            if (id != disaster_allocation.Inventory_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disaster_allocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!disaster_allocationExists(disaster_allocation.Inventory_ID))
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
            return View(disaster_allocation);
        }

        // GET: disaster_allocation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.disaster_allocation == null)
            {
                return NotFound();
            }

            var disaster_allocation = await _context.disaster_allocation
                .FirstOrDefaultAsync(m => m.Inventory_ID == id);
            if (disaster_allocation == null)
            {
                return NotFound();
            }

            return View(disaster_allocation);
        }

        // POST: disaster_allocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.disaster_allocation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.disaster_allocation'  is null.");
            }
            var disaster_allocation = await _context.disaster_allocation.FindAsync(id);
            if (disaster_allocation != null)
            {
                _context.disaster_allocation.Remove(disaster_allocation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool disaster_allocationExists(int id)
        {
          return (_context.disaster_allocation?.Any(e => e.Inventory_ID == id)).GetValueOrDefault();
        }
    }
}
