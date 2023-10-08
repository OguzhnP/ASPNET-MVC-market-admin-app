using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mopas.Entities;
using Mopas.Models;

namespace Mopas.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly MopasDbContext _context;

        public CategoryController(MopasDbContext context)
        {
            _context = context;
        }

        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    CategoryName = model.CategoryName,
                };

                _context.Categories.Add(category);
                _context.SaveChanges();
            }


            return View();
        }



        public IActionResult Index()
        {
            var categories = _context.Categories;
            return View(categories);
        }

        [HttpGet]
        public IActionResult DeleteCategory([FromRoute]int id)
        {
            var category = _context.Categories.SingleOrDefault(x => x.Id == id);

            _context.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult UpdateCategory([FromRoute]int id)
        {
            var category = _context.Categories.SingleOrDefault(x=>x.Id == id);
            return View(category);
        }

        [HttpPost]
         public IActionResult UpdateCategory(Category model)
        { 
             
                var category = _context.Categories.SingleOrDefault(x=>x.Id == model.Id);

                category.CategoryName = model.CategoryName;
                category.Id = model.Id;

                _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }





    }
}
