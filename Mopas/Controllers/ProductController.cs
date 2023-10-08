using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mopas.Entities;
using Mopas.Models;

namespace Mopas.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly MopasDbContext _context;

        public ProductController(MopasDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products;
             
            return View(products);
        }

        public IActionResult CreateProduct()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "CategoryName");

            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product= new Product()
                { 
                  ProductName = model.ProductName,
                  Description = model.Description,
                  Price = model.Price,
                  Stock = model.Stock,
                  CategoryId = model.CategoryId,
                  Category = _context.Categories.SingleOrDefault(c=>c.Id == model.CategoryId)
                };

                _context.Products.Add(product);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult DeleteProduct([FromRoute] int id)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == id);

            _context.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult UpdateProduct([FromRoute] int id)
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "CategoryName");

            var product = _context.Products.SingleOrDefault(x => x.Id == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product model)
        {

            var product = _context.Products.SingleOrDefault(x => x.Id == model.Id);

            product.Id= model.Id;
            product.ProductName=model.ProductName;
            product.Description=model.Description;
            product.Price=model.Price;  
            product.Stock=model.Stock;
            product.CategoryId=model.CategoryId;
             

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
