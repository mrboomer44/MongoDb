using Microsoft.AspNetCore.Authorization;
using MongoDb.Dtos.StoryVideoDto;
using MongoDb.Services.StoryVideoServices;
using Microsoft.AspNetCore.Mvc;

namespace MongoDb.Controllers
{
    [Authorize]
    public class StoryVideoController : Controller
    {
        private readonly IStoryVideoServices _storyVideoServices;
        public StoryVideoController(IStoryVideoServices storyVideoServices)
        {
            _storyVideoServices = storyVideoServices;
        }
        public async Task<IActionResult> StoryVideoList()
        {
            var values = await _storyVideoServices.GetAllStoryVideosAsyn();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateStoryVideo()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateStoryVideo(CreateStoryVideoDto _createStoryVideoDto)
        {
            await _storyVideoServices.CreateStoryVideoAsyn(_createStoryVideoDto);
            return RedirectToAction("StoryVideoList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateStoryVideo()
        {
            var values = await _storyVideoServices.GetAllStoryVideosAsyn();
            var value = values.FirstOrDefault();
            if (value == null) return RedirectToAction("CreateStoryVideo");
            var updateDto = new UpdateStoryVideoDto
            {
                StoryVideoId = value.StoryVideoId,
                Title = value.Title,
                Description = value.Description,
                VideoUrl = value.VideoUrl,
                ImageUrl = value.ImageUrl
            };
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStoryVideo(UpdateStoryVideoDto updateStoryVideoDto)
        {
            await _storyVideoServices.UpdateStoryVideoAsyn(updateStoryVideoDto);
            return RedirectToAction("StoryVideoList");
        }
    }
}

