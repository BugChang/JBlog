using JBlog.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JBlog.Web.Areas.Admin.Controllers
{
    public class ArticleController : AdminController
    {
        public IActionResult Write(int? id)
        {
            if (id.HasValue)
            {

            }
            return View();
        }

        [HttpPost]
        public IActionResult SaveDraft(ArticleWriteViewModel viewModel)
        {
            return View("Write");
        }

        [HttpPost]
        public IActionResult Publish(ArticleWriteViewModel viewModel)
        {
            viewModel.IsPublish = true;
            return View("wr");
        }
    }
}
