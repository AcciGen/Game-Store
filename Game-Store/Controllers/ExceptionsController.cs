using Game_Store.Models;
using Microsoft.AspNetCore.Mvc;

namespace Game_Store.Controllers
{
    public class ExceptionsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Error(string message, int code)
        {
            ExceptionViewModel model = new ExceptionViewModel()
            {
                Code = code,
                Message = message
            };
            return View(model);
        }
        public IActionResult NotFound()
        {
            return View();
        }
    }
}
