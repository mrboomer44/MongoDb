using Microsoft.AspNetCore.Mvc;

namespace MongoDb.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
