using FormsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FormsApp.Controllers;

public class HomeController : Controller
{
	[HttpGet]
	public IActionResult Index(string searchString, string category)
	{
		var products = Repository.Products;

		if (!string.IsNullOrEmpty(searchString))
		{
			ViewBag.SearchString = searchString;
			products = products.Where(s => 
				s.Name.Contains(searchString)).ToList();
		}

		if (!string.IsNullOrEmpty(category) && category != "0")
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

	[HttpGet]
	public IActionResult Create()
	{
		ViewBag.Categories = new SelectList(Repository.Categories, "categoryId", "categoryName");
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Create(Product product, IFormFile imageFile)
	{
		var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
		var extension = Path.GetExtension(imageFile.FileName);	//abc.jpg
		var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
		var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

		if (imageFile != null)
		{
			if (!allowedExtensions.Contains(extension))
			{
				ModelState.AddModelError("","Geçerli bir resim seçiniz.");
			}
		}

		if (ModelState.IsValid)
		{
			if (imageFile != null)
			{
				using (var stream = new FileStream(path, FileMode.Create))
				{
					await imageFile.CopyToAsync(stream);
				}
			}
			product.Image = randomFileName;
			product.Id = Repository.Products.Count + 1;
			Repository.CreateProduct(product);
			return RedirectToAction("Index");
		}

		ViewBag.Categories = new SelectList(Repository.Categories, "categoryId", "categoryName");
		return View(product);
	}

	[HttpGet]
	public IActionResult Edit(int? id)
	{
		if (id == null)
		{
			return NotFound();
		}
		var entity = Repository.Products.FirstOrDefault(p => p.Id == id);
		
		if (entity == null)
		{
			return NotFound();
		}

		ViewBag.Category = new SelectList(Repository.Categories, "categoryId", "Name");
		return View(entity);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(int id, Product Model, IFormFile? imageFile)
	{
		if (id != Model.Id)
		{
			return NotFound();
		}

		if (ModelState.IsValid)
		{
			if (imageFile != null)
			{
				var extension = Path.GetExtension(imageFile.FileName);
				var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
				var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

				using (var stream = new FileStream(path, FileMode.Create))
				{
					await imageFile.CopyToAsync(stream);
				}

				Model.Image = randomFileName;
			}
			Repository.EditProduct(Model);

			return RedirectToAction("Index");
		}
		ViewBag.Category = new SelectList(Repository.Categories, "categoryId", "Name");
		return View(Model);
	}


	[HttpGet]
	public IActionResult Delete(int? id)
	{
		if(id == null)
		{
			return NotFound();
		}

		var entity = Repository.Products.FirstOrDefault(p => p.Id == id);
		if (entity == null) {
			return NotFound();
		}

		Repository.DeleteProduct(entity);
		return RedirectToAction("Index");
	}
}