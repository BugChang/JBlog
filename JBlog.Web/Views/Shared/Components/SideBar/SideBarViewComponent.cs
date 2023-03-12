using Microsoft.AspNetCore.Mvc;

namespace JBlog.Web.Views.Shared.Components.SideBar
{
    public class SideBarViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
