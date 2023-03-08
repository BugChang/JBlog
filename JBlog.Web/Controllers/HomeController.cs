using JBlog.Application.AppInterfaces;
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

        public async Task<IActionResult> Index()
        {
            var model = await _articleAppService.GetListAsync();
            return View(model);
        }
    }
}
