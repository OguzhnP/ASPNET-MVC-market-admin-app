using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mopas.Entities;
using Mopas.Models;

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
            var salesReport = _context.SalesReports
                .Include(sr => sr.Products)  
                .FirstOrDefault(sr => sr.Id == id);

            if (salesReport == null)
            {
                return NotFound();
            }

            var viewModel = new SalesReportDetailViewModel
            {
                SalesReport = salesReport,
                Products = salesReport.Products.ToList()  
            };

            return View(viewModel);
        }


        public IActionResult CreateSale()
        {
            ViewBag.Products = new SelectList(_context.Products, "Id", "ProductName");

            return View();
        }

        [HttpPost]
        public IActionResult CreateSale(SalesReportViewModel viewModel)
        {
            var salesReport = new SalesReport
            {
                SalesName = viewModel.SalesName,
                SalesDate = viewModel.SalesDate, 
            };


            decimal totalSalesPrice = 0;
            foreach (var productId in viewModel.SelectedProductIds)
            {
                var product = _context.Products.SingleOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    salesReport.Products.Add(product);
                    totalSalesPrice += product.Price;
                }
            }
            salesReport.SalesQuantity = totalSalesPrice;
            _context.SalesReports.Add(salesReport);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult DeleteSaleReport([FromRoute]int id)
        {
            var salesReport = _context.SalesReports.SingleOrDefault(sr =>sr.Id == id);
 

            _context.SalesReports.Remove(salesReport);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }



    }
}
