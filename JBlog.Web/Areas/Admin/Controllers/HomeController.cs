using Microsoft.AspNetCore.Mvc;

namespace JBlog.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
