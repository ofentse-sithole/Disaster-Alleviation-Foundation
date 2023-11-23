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
    public class Allocation_MoneyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Allocation_MoneyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Allocation_Money
        public async Task<IActionResult> Index()
        {
              return _context.Allocation_Money != null ? 
                          View(await _context.Allocation_Money.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Allocation_Money'  is null.");
        }

        // GET: Allocation_Money/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Allocation_Money == null)
            {
                return NotFound();
            }

            var allocation_Money = await _context.Allocation_Money
                .FirstOrDefaultAsync(m => m.All_MoneyID == id);
            if (allocation_Money == null)
            {
                return NotFound();
            }

            return View(allocation_Money);
        }

        // GET: Allocation_Money/Create
        public IActionResult Create()
        {
            ViewBag.DisasterItems = new SelectList(_context.disaster, "Disaster_ID", "Disaster_ID");
            return View();
        }

        // POST: Allocation_Money/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("All_MoneyID,Disaster_id,Money_allocate,Allocate_Date")] Allocation_Money allocation_Money)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allocation_Money);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allocation_Money);
        }

        // GET: Allocation_Money/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Allocation_Money == null)
            {
                return NotFound();
            }

            var allocation_Money = await _context.Allocation_Money.FindAsync(id);
            if (allocation_Money == null)
            {
                return NotFound();
            }
            return View(allocation_Money);
        }

        // POST: Allocation_Money/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("All_MoneyID,Disaster_id,Money_allocate,Allocate_Date")] Allocation_Money allocation_Money)
        {
            if (id != allocation_Money.All_MoneyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allocation_Money);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Allocation_MoneyExists(allocation_Money.All_MoneyID))
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
            return View(allocation_Money);
        }

        // GET: Allocation_Money/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Allocation_Money == null)
            {
                return NotFound();
            }

            var allocation_Money = await _context.Allocation_Money
                .FirstOrDefaultAsync(m => m.All_MoneyID == id);
            if (allocation_Money == null)
            {
                return NotFound();
            }

            return View(allocation_Money);
        }

        // POST: Allocation_Money/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Allocation_Money == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Allocation_Money'  is null.");
            }
            var allocation_Money = await _context.Allocation_Money.FindAsync(id);
            if (allocation_Money != null)
            {
                _context.Allocation_Money.Remove(allocation_Money);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Allocation_MoneyExists(int id)
        {
          return (_context.Allocation_Money?.Any(e => e.All_MoneyID == id)).GetValueOrDefault();
        }

        //Used within the UnitTest
        private const int LIMIT = 8;
        private int limitBalance;

        public int LimitBalance { get { return limitBalance; } set { limitBalance = value; } }

        public void checkList(int limit)
        {
            if (limit < 0)
            {
                throw new ArgumentOutOfRangeException("limit", limit, "The value was lesser than 0");
            }

            if (limit > LIMIT) // Ensure LIMIT is declared and has the correct value
            {
                throw new ArgumentOutOfRangeException("limit", limit, "The value exceeds the limit");
            }

            limitBalance -= limit;
        }
    }
}
