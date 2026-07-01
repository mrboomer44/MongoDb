using MongoDb.Models;
using MongoDb.Services.AboutListServices;
using MongoDb.Services.AboutSection2Services;
using Microsoft.AspNetCore.Mvc;

namespace MongoDb.ViewComponents
{
    public class _DefaultAboutSecion2ComponentPartial : ViewComponent
    {
        private readonly IAboutSection2Services _aboutSection2Services;
        private readonly IAboutListServices _aboutListServices;

        public _DefaultAboutSecion2ComponentPartial(IAboutSection2Services aboutSection2Services, IAboutListServices aboutListServices)
        {
            _aboutSection2Services = aboutSection2Services;
            _aboutListServices = aboutListServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var section2 = (await _aboutSection2Services.GetAllAboutSection2Asyn()).FirstOrDefault();
            var list = await _aboutListServices.GetAllAboutListAsyn();

            var model = new AboutSection2ViewModel
            {
                AboutSection2 = section2,
                AboutList = list
            };

            return View(model);
        }
    }
}
