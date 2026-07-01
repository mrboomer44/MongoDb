using MongoDb.Services.FaqServices;
using Microsoft.AspNetCore.Mvc;

namespace MongoDb.ViewComponents
{
    public class _DefaultFaqComponentPartial : ViewComponent
    {
        private readonly IFaqServices _faqServices;
        public _DefaultFaqComponentPartial(IFaqServices faqServices)
        {
            _faqServices = faqServices;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _faqServices.GetAllFaqAsyn();
            return View(values);
        }
    }
}