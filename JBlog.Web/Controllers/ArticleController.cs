using JBlog.Application.AppInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace JBlog.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleAppService _articleAppService;

        public ArticleController(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
        }

        public async Task<IActionResult> Index(int id)
        {
          var model= await _articleAppService.GetByIdAsync(id);
            return View(model);
        }
    }
}
