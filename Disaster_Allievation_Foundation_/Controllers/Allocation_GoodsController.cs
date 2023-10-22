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
    public class Allocation_GoodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Allocation_GoodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Allocation_Goods
        public async Task<IActionResult> Index()
        {
              return _context.Allocation_Goods != null ? 
                          View(await _context.Allocation_Goods.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Allocation_Goods'  is null.");
        }

        // GET: Allocation_Goods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Allocation_Goods == null)
            {
                return NotFound();
            }

            var allocation_Goods = await _context.Allocation_Goods
                .FirstOrDefaultAsync(m => m.All_GoodsID == id);
            if (allocation_Goods == null)
            {
                return NotFound();
            }

            return View(allocation_Goods);
        }

        // GET: Allocation_Goods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Allocation_Goods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("All_GoodsID,Disaster_ID,GoodsDonation_ID,Goods_Items,Allocate_Date")] Allocation_Goods allocation_Goods)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allocation_Goods);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allocation_Goods);
        }

        // GET: Allocation_Goods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Allocation_Goods == null)
            {
                return NotFound();
            }

            var allocation_Goods = await _context.Allocation_Goods.FindAsync(id);
            if (allocation_Goods == null)
            {
                return NotFound();
            }
            return View(allocation_Goods);
        }

        // POST: Allocation_Goods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("All_GoodsID,Disaster_ID,GoodsDonation_ID,Goods_Items,Allocate_Date")] Allocation_Goods allocation_Goods)
        {
            if (id != allocation_Goods.All_GoodsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allocation_Goods);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Allocation_GoodsExists(allocation_Goods.All_GoodsID))
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
            return View(allocation_Goods);
        }

        // GET: Allocation_Goods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Allocation_Goods == null)
            {
                return NotFound();
            }

            var allocation_Goods = await _context.Allocation_Goods
                .FirstOrDefaultAsync(m => m.All_GoodsID == id);
            if (allocation_Goods == null)
            {
                return NotFound();
            }

            return View(allocation_Goods);
        }

        // POST: Allocation_Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Allocation_Goods == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Allocation_Goods'  is null.");
            }
            var allocation_Goods = await _context.Allocation_Goods.FindAsync(id);
            if (allocation_Goods != null)
            {
                _context.Allocation_Goods.Remove(allocation_Goods);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Allocation_GoodsExists(int id)
        {
          return (_context.Allocation_Goods?.Any(e => e.All_GoodsID == id)).GetValueOrDefault();
        }
    }
}
