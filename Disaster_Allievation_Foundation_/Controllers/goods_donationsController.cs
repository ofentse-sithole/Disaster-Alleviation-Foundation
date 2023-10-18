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
    public class goods_donationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public goods_donationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: goods_donations
        public async Task<IActionResult> Index()
        {
              return _context.goods_donations != null ? 
                          View(await _context.goods_donations.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.goods_donations'  is null.");
        }

        // GET: goods_donations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.goods_donations == null)
            {
                return NotFound();
            }

            var goods_donations = await _context.goods_donations
                .FirstOrDefaultAsync(m => m.GoodID == id);
            if (goods_donations == null)
            {
                return NotFound();
            }

            return View(goods_donations);
        }

        // GET: goods_donations/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: goods_donations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GoodID,Donor,num_items,category,description")] goods_donations goods_donations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goods_donations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goods_donations);
        }

        // GET: goods_donations/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.goods_donations == null)
            {
                return NotFound();
            }

            var goods_donations = await _context.goods_donations.FindAsync(id);
            if (goods_donations == null)
            {
                return NotFound();
            }
            return View(goods_donations);
        }

        // POST: goods_donations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GoodID,Donor,num_items,category,description")] goods_donations goods_donations)
        {
            if (id != goods_donations.GoodID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goods_donations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!goods_donationsExists(goods_donations.GoodID))
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
            return View(goods_donations);
        }

        // GET: goods_donations/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.goods_donations == null)
            {
                return NotFound();
            }

            var goods_donations = await _context.goods_donations
                .FirstOrDefaultAsync(m => m.GoodID == id);
            if (goods_donations == null)
            {
                return NotFound();
            }

            return View(goods_donations);
        }

        // POST: goods_donations/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.goods_donations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.goods_donations'  is null.");
            }
            var goods_donations = await _context.goods_donations.FindAsync(id);
            if (goods_donations != null)
            {
                _context.goods_donations.Remove(goods_donations);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool goods_donationsExists(int id)
        {
          return (_context.goods_donations?.Any(e => e.GoodID == id)).GetValueOrDefault();
        }
    }
}
