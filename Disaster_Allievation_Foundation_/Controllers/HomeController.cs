using Disaster_Allievation_Foundation_.Data;
using Disaster_Allievation_Foundation_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Disaster_Allievation_Foundation_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel
            {

                disaster = await _context.disaster.ToListAsync(),
                Allocation_Goods = await _context.Allocation_Goods.ToListAsync(),
                Allocation_Money = await _context.Allocation_Money.ToListAsync(),
                monetary_donations = await _context.monetary_donations.ToListAsync(),
                goods_donations = await _context.goods_donations.ToListAsync(),

                monetaryDonations = await _context.monetary_donations.SumAsync(m => m.Amount),
                totalAllocatedMoney = await _context.Allocation_Money.SumAsync(m => m.Money_allocate),
                totalMoney = await _context.monetary_donations.SumAsync(m => m.Amount) - await _context.Allocation_Money.SumAsync(m => m.Money_allocate)


            };
               
            return View(viewModel);
    }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}