using Microsoft.AspNetCore.Mvc;

namespace MongoDb.ViewComponents
{
    public class _DefaultCopyrigthComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
