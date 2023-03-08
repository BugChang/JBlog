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
            return View("Edit");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _categoryAppService.GetByIdAsync(id);
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _categoryAppService.GetByIdAsync(id);
            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Save(CategoryViewModel viewModel)
        {
            if (viewModel.Id > 0)
            {
                await _categoryAppService.UpdateAsync(viewModel);
            }
            else
            {
                await _categoryAppService.AddAsync(viewModel);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await _categoryAppService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
