using MongoDb.Services.AboutSection1Services;
using Microsoft.AspNetCore.Mvc;

namespace MongoDb.ViewComponents
{
    public class _DefaultAboutSecion1ComponentPartial : ViewComponent
    {
        private readonly IAboutSection1Services _aboutSection1;

        public _DefaultAboutSecion1ComponentPartial(IAboutSection1Services aboutSection1)
        {
            _aboutSection1 = aboutSection1;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutSection1.GetAllAboutSection1Asyn();
            var value = values.FirstOrDefault();
            return View(value);
        }
    }
}
