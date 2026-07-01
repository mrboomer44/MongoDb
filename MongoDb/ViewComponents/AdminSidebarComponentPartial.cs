using Microsoft.AspNetCore.Mvc;

namespace MongoDb.ViewComponents
{
    public class AdminSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}