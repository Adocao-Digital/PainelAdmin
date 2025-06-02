using Microsoft.AspNetCore.Mvc;

namespace PainelAdmin.Controllers
{
    public class LoginResponse : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
