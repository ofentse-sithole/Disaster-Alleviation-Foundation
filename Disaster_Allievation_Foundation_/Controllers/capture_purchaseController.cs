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
    public class capture_purchaseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public capture_purchaseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: capture_purchase
        public async Task<IActionResult> Index()
        {
              return _context.capture_purchase != null ? 
                          View(await _context.capture_purchase.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.capture_purchase'  is null.");
        }

        // GET: capture_purchase/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.capture_purchase == null)
            {
                return NotFound();
            }

            var capture_purchase = await _context.capture_purchase
                .FirstOrDefaultAsync(m => m.ID == id);
            if (capture_purchase == null)
            {
                return NotFound();
            }

            return View(capture_purchase);
        }

        // GET: capture_purchase/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewBag.DisasterItems = new SelectList(_context.disaster, "Disaster_ID", "Disaster_ID");
            ViewBag.GoodsItems = new SelectList(_context.goods_donations, "GoodID", "GoodID");
            ViewBag.MonetaryItems = new SelectList(_context.monetary_donations, "Monetary_ID", "Monetary_ID");
            return View();
        }

        // POST: capture_purchase/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DisasterID,GoodsDonationID,MonetaryDonationID,PurchaseDate,PurchaseAmount")] capture_purchase capture_purchase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(capture_purchase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(capture_purchase);
        }

        // GET: capture_purchase/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.capture_purchase == null)
            {
                return NotFound();
            }

            var capture_purchase = await _context.capture_purchase.FindAsync(id);
            if (capture_purchase == null)
            {
                return NotFound();
            }
            return View(capture_purchase);
        }

        // POST: capture_purchase/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DisasterID,GoodsDonationID,MonetaryDonationID,PurchaseDate,PurchaseAmount")] capture_purchase capture_purchase)
        {
            if (id != capture_purchase.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(capture_purchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!capture_purchaseExists(capture_purchase.ID))
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
            return View(capture_purchase);
        }

        // GET: capture_purchase/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.capture_purchase == null)
            {
                return NotFound();
            }

            var capture_purchase = await _context.capture_purchase
                .FirstOrDefaultAsync(m => m.ID == id);
            if (capture_purchase == null)
            {
                return NotFound();
            }

            return View(capture_purchase);
        }

        // POST: capture_purchase/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.capture_purchase == null)
            {
                return Problem("Entity set 'ApplicationDbContext.capture_purchase'  is null.");
            }
            var capture_purchase = await _context.capture_purchase.FindAsync(id);
            if (capture_purchase != null)
            {
                _context.capture_purchase.Remove(capture_purchase);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool capture_purchaseExists(int id)
        {
          return (_context.capture_purchase?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
