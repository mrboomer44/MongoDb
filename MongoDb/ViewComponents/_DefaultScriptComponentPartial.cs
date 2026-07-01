using Microsoft.AspNetCore.Mvc;

namespace MongoDb.ViewComponents
{
    public class _DefaultScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
