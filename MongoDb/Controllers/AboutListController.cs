using Microsoft.AspNetCore.Authorization;
using MongoDb.Dtos.AboutListDto;
using MongoDb.Services.AboutListServices;
using Microsoft.AspNetCore.Mvc;

namespace MongoDb.Controllers
{
    [Authorize]
    public class AboutListController : Controller
    {
        private readonly IAboutListServices _aboutListServices;

        public AboutListController(IAboutListServices aboutListServices)
        {
            _aboutListServices = aboutListServices;
        }

        public async Task<IActionResult> AboutListList()
        {
            var values = await _aboutListServices.GetAllAboutListAsyn();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateAboutList()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAboutList(CreateAboutListDto _createAboutListDto)
        {
            await _aboutListServices.CreateAboutListAsyn(_createAboutListDto);
            return RedirectToAction("AboutListList");
        }
        public async Task<IActionResult> DeleteAboutList(string id)
        {
            await _aboutListServices.DeleteAboutListAsyn(id);
            return RedirectToAction("AboutListList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAboutList(string id)
        {
            var value = await _aboutListServices.GetAboutListByIdDto(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAboutList(UpdateAboutListDto _updateAboutListDto)
        {
            await _aboutListServices.UpdateAboutListAsyn(_updateAboutListDto);
            return RedirectToAction("AboutListList");
        }
    }
}

