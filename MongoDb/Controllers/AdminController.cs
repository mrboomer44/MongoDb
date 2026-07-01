using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using MongoDb.Services.LoginServices;

namespace MongoDb.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILoginServices _loginServices;
        private readonly IMemoryCache _memoryCache;

        public AdminController(ILoginServices loginServices, IMemoryCache memoryCache)
        {
            _loginServices = loginServices;
            _memoryCache = memoryCache;
        }

        public IActionResult _AdminLayout()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "BilinmeyenIP";
            var ramAnahtari = $"BanliMi_{ip}";

            if (_memoryCache.TryGetValue(ramAnahtari, out int hataSayisi))
            {
                if (hataSayisi >= 3)
                {
                    ViewBag.Error = "3 defa yanlış şifre girdiniz. 24 Saat banlandınız!";
                    return View(); 
                }
            }
            else
            {
                hataSayisi = 0; 
            }

            var adminler = await _loginServices.GetAllLoginsAsync();
            var adminUser = adminler.FirstOrDefault();

            if (adminUser != null && 
                string.Equals(adminUser.UserName.Trim(), username.Trim(), StringComparison.OrdinalIgnoreCase) && 
                adminUser.Password.Trim() == password.Trim())
            {
                _memoryCache.Remove(ramAnahtari);

                var claims = new List<Claim> { new Claim(ClaimTypes.Name, adminUser.UserName) };
                var identity = new ClaimsIdentity(claims, "AdminCookies");
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("AdminCookies", principal);

                return RedirectToAction("AboutListList", "AboutList");
            }
            else
            {
                hataSayisi++; 
                var ramAyari = new MemoryCacheEntryOptions();

                if (hataSayisi >= 3)
                {
                    ramAyari.SetAbsoluteExpiration(TimeSpan.FromHours(24));
                    ViewBag.Error = "Şifre Yanlış! 3 hakkınız doldu, 24 saat engellendiniz.";
                }
                else
                {
                    ramAyari.SetAbsoluteExpiration(TimeSpan.FromMinutes(15));
                    ViewBag.Error = $"Şifre Yanlış! Kalan hakkınız: {3 - hataSayisi}";
                }

                _memoryCache.Set(ramAnahtari, hataSayisi, ramAyari);

                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync("AdminCookies");
            return RedirectToAction("Index", "Default");
        }
    }
}
