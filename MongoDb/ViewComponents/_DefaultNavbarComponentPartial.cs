using Microsoft.AspNetCore.Mvc;

namespace MongoDb.ViewComponents
{
    public class _DefaultNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
