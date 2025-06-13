using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PainelAdmin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using PainelAdmin.Models.ViewModels;
using System.Drawing;
using MongoDB.Driver.Linq;

namespace PainelAdmin.Controllers
{
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

        public IActionResult Index()
        {
            var noticias = _context.Noticia
                .Find(_ => true) // busca todos os documentos
                .SortByDescending(n => n.DataPublicacao) // ou n => n.Id se não houver campo DataPublicacao
                .Limit(3)
                .ToList();

            return View(noticias);
        }

        public IActionResult Sobre()
        {
            return View();
        }

        public IActionResult FaleConosco()
        {
            return View();
        }

        public async Task<IActionResult> QueroAdotar()
        {
            var pet = await _context.Pet
                .Find(p => p.Situacao == "Adocao")
                .SortByDescending(p => p.Id)
                .ToListAsync();
            return View(pet);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Filtrar([FromBody] FiltroPetModel filtros)
        {
            var pets = _context.Pet.AsQueryable().Where(p => p.Situacao == "Adocao");

            if (filtros.Especie?.Any() == true)
                pets = pets.Where(p => filtros.Especie.Contains(p.Especie.ToLower()));

            if (filtros.Idade?.Any() == true)
                pets = pets.Where(p => filtros.Idade.Contains(p.Idade.ToLower()));

            if (filtros.Porte?.Any() == true)
                pets = pets.Where(p => filtros.Porte.Contains(p.Porte.ToLower()));

            if (filtros.Sexo?.Any() == true)
                pets = pets.Where(p => filtros.Sexo.Contains(p.Sexo.ToLower()));

            var resultado = pets.ToList();

            return PartialView("_CardsAnimais", resultado);
        }

    }
}
