using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PainelAdmin.Models;
using PainelAdmin.Data;
using MongoDB.Driver;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace PainelAdmin.Controllers
{
    [Authorize(Roles = "ADM")]
    public class PainelController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        ContextMongodb _context = new ContextMongodb();

        public PainelController(UserManager<ApplicationUser> userManager)
        {
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
    }
}
