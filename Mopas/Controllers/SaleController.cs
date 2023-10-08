using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mopas.Entities;

namespace Mopas.Controllers
{
    [Authorize]
    public class SaleController : Controller
    {
        private readonly MopasDbContext _context;

        public SaleController(MopasDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var salesReports = _context.SalesReports;

            return View(salesReports);
        }
        
        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var salesReport = _context.SalesReports.Find(id);
            return View(salesReport);
        }
    }
}
