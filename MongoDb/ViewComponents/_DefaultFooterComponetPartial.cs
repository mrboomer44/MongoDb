using Microsoft.AspNetCore.Mvc;

namespace MongoDb.ViewComponents
{
    public class _DefaultFooterComponetPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
