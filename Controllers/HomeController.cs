using FormsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace FormsApp.Controllers
{
    public class HomeController : Controller
    {
       

        public HomeController()
        {
        }

        public IActionResult Index(string searchString,string category)
        {
            var products = Repository.Products; 

            if (!string.IsNullOrEmpty(searchString))
            {
                ViewBag.SearchString = searchString;
                products = products.Where(s => s.Name.Contains(searchString)).ToList();
            }

            if (!string.IsNullOrEmpty(category) && category !=  "0")
            {
                ViewBag.Category = category;
                products = products.Where(s => s.CategoryId.ToString() == category).ToList();
            }

            // ViewBag.Categories = new SelectList(Repository.Categories, "categoryId", "categoryName",category);
            
            var model = new ProductViewModel
            {
                Products = products,
                Categories = Repository.Categories,
                SelectedCategory = category
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
