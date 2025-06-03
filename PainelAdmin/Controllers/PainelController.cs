using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PainelAdmin.Models;
using PainelAdmin.Data;
using MongoDB.Driver;

namespace PainelAdmin.Controllers
{
    public class PainelController : Controller
    {
        ContextMongodb _context = new ContextMongodb();
        public IActionResult Index()
        {
            var noticias = _context.Noticia
                .Find(_ => true) // busca todos os documentos
                .SortByDescending(n => n.DataPublicacao) // ou n => n.Id se não houver campo DataPublicacao
                .Limit(3)
                .ToList();

            return View(noticias);
        }
    }
}
