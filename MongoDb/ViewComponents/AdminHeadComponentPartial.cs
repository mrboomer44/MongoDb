using Microsoft.AspNetCore.Mvc;

namespace MongoDb.ViewComponents
{
    public class AdminHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}