using Microsoft.AspNetCore.Authorization;
using MongoDb.Dtos.AboutSection2Dto;
using MongoDb.Services.AboutSection2Services;
using Microsoft.AspNetCore.Mvc;

namespace MongoDb.Controllers
{
    [Authorize]
    public class AboutSection2Controller : Controller
    {
        private readonly IAboutSection2Services aboutSection2Services;
        public AboutSection2Controller(IAboutSection2Services aboutSection2Services)
        {
            this.aboutSection2Services = aboutSection2Services;
        }
        public async Task<IActionResult> AboutSection2List()
        {
            var values = await aboutSection2Services.GetAllAboutSection2Asyn();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateAboutSection2()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAboutSection2(CreateAboutSection2Dto _createAboutSection2Dto)
        {
            await aboutSection2Services.CreateAboutSection2Asyn(_createAboutSection2Dto);
            return RedirectToAction("AboutSection2List");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAboutSection2()
        {
            var value = await aboutSection2Services.GetAllAboutSection2Asyn();
            var values = value.FirstOrDefault();
            if (values == null) { return RedirectToAction("CreateAboutSection2"); }
            var UpdateAboutSection2Dto = new UpdateAboutSection2Dto
            {
                AboutSection2Id = values.AboutSection2Id,
                Title = values.Title,
                Description = values.Description,
                ImageUrl = values.ImageUrl
            };
            return View(UpdateAboutSection2Dto);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAboutSection2(UpdateAboutSection2Dto updateAboutSection2Dto)
        {
            await aboutSection2Services.UpdateAboutSection2Asyn(updateAboutSection2Dto);
            return RedirectToAction("AboutSection2List");
        }
    }
}

