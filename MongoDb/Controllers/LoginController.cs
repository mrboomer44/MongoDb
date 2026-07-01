using Microsoft.AspNetCore.Authorization;
using MongoDb.Dtos.LoginDto;
using MongoDb.Services.LoginServices;
using Microsoft.AspNetCore.Mvc;

namespace MongoDb.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        private readonly ILoginServices _loginServices;

        public LoginController(ILoginServices loginServices)
        {
            _loginServices = loginServices;
        }

        public async Task<IActionResult> LoginList()
        {
            var values = await _loginServices.GetAllLoginsAsync();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateLogin(CreateLoginDto _createLoginDto)
        {
            await _loginServices.CreateLoginAsync(_createLoginDto);
            return RedirectToAction("LoginList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateLogin(string id)
        {
            var value = await _loginServices.GetLoginByIdDto(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateLogin(UpdateLoginDto _updateLoginDto)
        {
            await _loginServices.UpdateLoginAsync(_updateLoginDto);
            return RedirectToAction("LoginList");
        }
    }
}

