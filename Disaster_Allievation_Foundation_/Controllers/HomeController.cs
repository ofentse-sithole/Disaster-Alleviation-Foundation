using Disaster_Allievation_Foundation_.Data;
using Disaster_Allievation_Foundation_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Disaster_Allievation_Foundation_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //Calcuations for Total Goods Donations

            //Calculation for Total Monetary Donations
            int monetaryDonations = _context.monetary_donations.Sum(md => md.Amount);

            //calculation for Available Money
            int totalAllocatedMoney = _context.Allocation_Money.Sum(am => am.Money_allocate);
            int availableMoney = monetaryDonations - totalAllocatedMoney;

            ViewBag.monetaryDonations = monetaryDonations;
            ViewBag.totalAllocatedMoney = totalAllocatedMoney;
            ViewBag.AvailableMoney = availableMoney;
            return View();
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