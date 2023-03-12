using JBlog.Application.AppInterfaces;
using JBlog.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleAppService _articleAppService;

        public HomeController(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
        }

        public async Task<IActionResult> Index(int page = 1, int size = 10)
        {
            var query = new ArticleQuery
            {
                Page = page,
                PageSize = size
            };
            var model = await _articleAppService.GetListAsync(query);
            return View(model);
        }


        public IActionResult Article(int id)
        {
            return View();
        }


    }
}
