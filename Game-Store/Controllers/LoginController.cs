using Microsoft.AspNetCore.Mvc;

namespace Game_Store.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
