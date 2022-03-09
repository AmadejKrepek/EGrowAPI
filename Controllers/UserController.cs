using Microsoft.AspNetCore.Mvc;

namespace EGrowAPI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
