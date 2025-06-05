using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PainelAdmin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using PainelAdmin.Models.ViewModels;
using System.Drawing;

namespace PainelAdmin.Controllers
{
    [Authorize]
    [Route("painel/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        ContextMongodb _context = new ContextMongodb();


        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            
            var contadorAdocao = await _context.Pet.CountDocumentsAsync(p => p.Situacao == "Adocao");
            ViewBag.ContadorPetAdocao = contadorAdocao;

            var contadorComTutor = await _context.Pet.CountDocumentsAsync(p => p.Situacao == "ComTutor");
            ViewBag.ContadorPetComTutor = contadorComTutor;

            var AllUser = await _context.Usuarios.Find(_ => true).ToListAsync();
            int contadorUser = 0;
            int contadorADM = 0;
            foreach (var user in AllUser)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("ADM"))
                {
                    contadorADM++;
                }
                else
                {
                    contadorUser++;
                }
            }

            ViewBag.ContadorFuncionarios = contadorADM;
            ViewBag.ContadorTutores = contadorUser;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
