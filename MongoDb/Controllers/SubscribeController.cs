using Microsoft.AspNetCore.Authorization;
using MongoDb.Dtos.SubscribeDto;
using MongoDb.Services.SubscribeServices;
using Microsoft.AspNetCore.Mvc;

namespace MongoDb.Controllers
{
    [Authorize]
    public class SubscribeController : Controller
    {
        private readonly ISubscribeServices _subscribeServices;

        public SubscribeController(ISubscribeServices subscribeServices)
        {
            _subscribeServices = subscribeServices;
        }

        public async Task<IActionResult> SubscribeList()
        {
            var values = await _subscribeServices.GetAllSubscribeAsyn();
            return View(values);
        }

        public async Task<IActionResult> DeleteSubscribe(string id)
        {
            await _subscribeServices.DeleteSubscribeAsyn(id);
            return RedirectToAction("SubscribeList");
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscribe(CreateSubscribeDto createSubscribeDto)
        {
            createSubscribeDto.SubscribeDate = DateTime.Now;
            await _subscribeServices.CreateSubscribeAsyn(createSubscribeDto);
            return RedirectToAction("Index", "Default");
        }
    }
}

