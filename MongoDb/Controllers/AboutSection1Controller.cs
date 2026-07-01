using Microsoft.AspNetCore.Authorization;
using MongoDb.Dtos.AboutSection1Dto;
using MongoDb.Services.AboutSection1Services;
using Microsoft.AspNetCore.Mvc;

namespace MongoDb.Controllers
{
    [Authorize]
    public class AboutSection1Controller : Controller
    {
        private readonly IAboutSection1Services _aboutSection1;

        public AboutSection1Controller(IAboutSection1Services aboutSection1)
        {
            _aboutSection1 = aboutSection1;
        }

        public async Task<IActionResult> AboutSection1List()
        {
            var values = await _aboutSection1.GetAllAboutSection1Asyn();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateAboutSection1()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAboutSection1(CreateAboutSection1Dto _createAboutSection1Dto)
        {
            await _aboutSection1.CreateAboutSection1Asyn(_createAboutSection1Dto);
            return RedirectToAction("AboutSection1List");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAboutSection1(string id)
        {
            var values = await _aboutSection1.GetAllAboutSection1Asyn();
            var value = values.FirstOrDefault();
            if (value == null) { return RedirectToAction("CreateAboutSection1"); }
            var updateAboutSection1Dto = new UpdateAboutSection1Dto
            {
                AboutSection1Id = value.AboutSection1Id,
                Title = value.Title,
                Description = value.Description,
                ImageUrl = value.ImageUrl
            };
            return View(updateAboutSection1Dto);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAboutSection1(UpdateAboutSection1Dto updateAboutSection1Dto)
        {
            await _aboutSection1.UpdateAboutSection1Asyn(updateAboutSection1Dto);
            return RedirectToAction("AboutSection1List");
        }
    }
}

