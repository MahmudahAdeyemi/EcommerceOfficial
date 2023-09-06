using EcommerceOfficial.Implementation.Services;
using EcommerceOfficial.Interfaces.Repositories;
using EcommerceOfficial.Interfaces.Services;
using EcommerceOfficial.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceOfficial.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult AddCategory()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(CategoryRequestModel categoryRequestModel)
        {

            var response = await _categoryService.AddCategory(categoryRequestModel);
            if (!response.Status)
            {
                return View(categoryRequestModel);
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetCategory(id);
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _categoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategories();
            return View(categories);
        }
    }
}
