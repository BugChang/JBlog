using JBlog.Application.AppInterfaces;
using JBlog.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JBlog.Web.Areas.Admin.Controllers
{
    public class CategoryController : AdminController
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryAppService.GetListAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryViewModel viewModel)
        {
            await _categoryAppService.AddAsync(viewModel);
            return RedirectToAction("Index");
        }
    }
}
