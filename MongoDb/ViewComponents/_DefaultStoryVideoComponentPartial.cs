using MongoDb.Services.StoryVideoServices;
using Microsoft.AspNetCore.Mvc;

namespace MongoDb.ViewComponents
{
    public class _DefaultStoryVideoComponentPartial : ViewComponent
    {
        private readonly IStoryVideoServices storyVideoServices;
        public _DefaultStoryVideoComponentPartial(IStoryVideoServices storyVideoServices)
        {
            this.storyVideoServices = storyVideoServices;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await storyVideoServices.GetAllStoryVideosAsyn();
            var value = values.FirstOrDefault();
            return View(value);
        }
    }
}
