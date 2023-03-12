using Microsoft.AspNetCore.Mvc;

namespace JBlog.Web.Views.Shared.Components.LeftMenu
{
    public class LeftMenuViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
