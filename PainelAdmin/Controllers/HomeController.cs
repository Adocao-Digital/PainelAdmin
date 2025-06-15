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
using System.Linq;

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
            var filtroFinal = filtroBuilder.Eq(p => p.Situacao, "Adocao");  // Só pets disponíveis para adoção

            // Filtro por espécie
            if (filtros.Especie != null && filtros.Especie.Any())
            {
                filtroFinal &= filtroBuilder.In(p => p.Especie, filtros.Especie);
            }

            // Filtro por porte
            if (filtros.Porte != null && filtros.Porte.Any())
            {
                filtroFinal &= filtroBuilder.In(p => p.Porte, filtros.Porte);
            }

            // Filtro por sexo
            if (filtros.Sexo != null && filtros.Sexo.Any())
            {
                filtroFinal &= filtroBuilder.In(p => p.Sexo, filtros.Sexo);
            }

            // Filtro por idade (traduzindo os checkboxes para faixas numéricas)
            if (filtros.Idade != null && filtros.Idade.Any())
            {
                var filtrosIdade = new List<FilterDefinition<Pet>>();

                if (filtros.Idade.Contains("filhote"))
                {
                    filtrosIdade.Add(filtroBuilder.Lte(p => p.Idade, 2));
                }

                if (filtros.Idade.Contains("adulto"))
                {
                    filtrosIdade.Add(filtroBuilder.And(
                        filtroBuilder.Gte(p => p.Idade, 3),
                        filtroBuilder.Lte(p => p.Idade, 6)
                    ));
                }

                if (filtros.Idade.Contains("idoso"))
                {
                    filtrosIdade.Add(filtroBuilder.Gte(p => p.Idade, 7));
                }

                filtroFinal &= filtroBuilder.Or(filtrosIdade);
            }

            // Busca no banco
            var petsFiltrados = await _context.Pet.Find(filtroFinal).ToListAsync();

            return PartialView("_CardsAnimais", petsFiltrados);
        }


    }
}
