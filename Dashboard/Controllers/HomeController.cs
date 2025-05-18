using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Models;
using Microsoft.AspNetCore.Identity;

namespace Dashboard.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<ApplicationUser> _userManager;


    public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        string? fotoPath = null;

        if (User.Identity?.IsAuthenticated ?? false)
        {
            var usuario = await _userManager.GetUserAsync(User);
            fotoPath = usuario?.Foto;
        }

        ViewBag.Foto = fotoPath ?? "/img/perfil/default.png";

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
