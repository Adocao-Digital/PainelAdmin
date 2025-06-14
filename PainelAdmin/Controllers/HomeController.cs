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
        public async Task<IActionResult> Filtrar([FromBody] FiltroPetModel filtros)
        {
            var filtroBuilder = Builders<Pet>.Filter;
            var filtroFinal = filtroBuilder.Empty;

            if (filtros.Especie != null && filtros.Especie.Any())
            {
                filtroFinal &= filtroBuilder.In(p => p.Especie, filtros.Especie);
            }

            if (filtros.Porte != null && filtros.Porte.Any())
            {
                filtroFinal &= filtroBuilder.In(p => p.Porte, filtros.Porte);
            }

            if (filtros.Sexo != null && filtros.Sexo.Any())
            {
                filtroFinal &= filtroBuilder.In(p => p.Sexo, filtros.Sexo);
            }

            if (filtros.Idade != null && filtros.Idade.Any())
            {
                // Se Idade é int?, pode ser bom garantir que p.Idade != null
                var faixa1 = filtroBuilder.Lte(p => p.Idade, 2); // até 2 anos
                var faixa2 = filtroBuilder.And(
                    filtroBuilder.Gte(p => p.Idade, 3),
                    filtroBuilder.Lte(p => p.Idade, 6)
                );

                var filtroFaixas = filtroBuilder.Or(faixa1, faixa2);
            }

            var petsFiltrados = await _context.Pet.Find(filtroFinal).ToListAsync();

            return PartialView("_CardsAnimais", petsFiltrados);
        }
    }
}
