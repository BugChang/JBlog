using JBlog.Application.AppInterfaces;
using JBlog.Application.AppServices;
using JBlog.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JBlog.Web.Areas.Admin.Controllers
{
    public class ArticleController : AdminController
    {
        private readonly IArticleAppService _articleAppService;
        private readonly ICategoryAppService _categoryAppService;

        public ArticleController(IArticleAppService articleAppService, ICategoryAppService categoryAppService)
        {
            _articleAppService = articleAppService;
            _categoryAppService = categoryAppService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _articleAppService.GetListAsync();
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var model = new ArticleViewModel();
            if (id.HasValue)
            {
                model = await _articleAppService.GetByIdAsync(id.Value);
            }

            var categories = await _categoryAppService.GetListAsync();
            ViewBag.Categories = categories;
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _articleAppService.GetByIdAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(ArticleViewModel viewModel)
        {
            if (viewModel.Id > 0)
            {
                await _articleAppService.UpdateAsync(viewModel);
            }
            else
            {
                await _articleAppService.AddAsync(viewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await _articleAppService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
