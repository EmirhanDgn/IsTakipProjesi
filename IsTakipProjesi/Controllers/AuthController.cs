using IsTakipProjesi.Data;
using IsTakipProjesi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace IsTakipProjesi.Controllers
{
    [SkipSessionCheck]
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            username = username.ToLower();
            var user = _context.Users
                .FirstOrDefault(u => u.Username.ToLower() == username && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserID", user.UserId.ToString());
                return RedirectToAction("Index", "Home");
            }

            // Kullanıcı bulunamazsa, bir hata mesajı gösterilebilir.
            ViewBag.ErrorMessage = "Geçersiz kullanıcı adı veya şifre";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Auth");
        }
    }
}
