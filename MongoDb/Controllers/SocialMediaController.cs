using Microsoft.AspNetCore.Authorization;
using MongoDb.Dtos.SocialMediaDto;
using MongoDb.Services.SocialMediaServices;
using Microsoft.AspNetCore.Mvc;

namespace MongoDb.Controllers
{
    [Authorize]
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaServices _socialMediaServices;
        public SocialMediaController(ISocialMediaServices socialMediaServices)
        {
            _socialMediaServices = socialMediaServices;
        }
        public async Task<IActionResult> SocialMediaList()
        {
            var values = await _socialMediaServices.GetAllSocialMediaAsyn();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto _createSocialMediaDto)
        {
            await _socialMediaServices.CreateSocialMediaAsyn(_createSocialMediaDto);
            return RedirectToAction("SocialMediaList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia()
        {
            var value = await _socialMediaServices.GetAllSocialMediaAsyn();
            var values = value.FirstOrDefault();
            if (values == null) { return RedirectToAction("CreateSocialMedia"); }
            var updateDto = new UpdateSocialMediaDto
            {
                SocialMediaId = values.SocialMediaId,
                Facebook = values.Facebook,
                Twitter = values.Twitter,
                Youtube = values.Youtube,
                Instagram = values.Instagram,
                LinkedIn = values.LinkedIn
            };
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto _updateSocialMediaDto)
        {
            await _socialMediaServices.UpdateSocialMediaAsyn(_updateSocialMediaDto);
            return RedirectToAction("SocialMediaList");
        }
    }
}

