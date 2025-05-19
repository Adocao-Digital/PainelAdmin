using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainelAdmin.Data;
using PainelAdmin.Models;
using MongoDB.Driver;
using System.Drawing;
using Microsoft.AspNetCore.Authorization;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Identity;
using PainelAdmin.Models.ViewModels;

namespace PainelAdmin.Controllers
{
    //[Authorize(Roles = "ADM")]
    public class NoticiasController : Controller
    {
        ContextMongodb _context = new ContextMongodb();

        private readonly UserManager<ApplicationUser> _userManager;

        public NoticiasController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        // GET: Noticias Atuais - mostra as 3 últimas criadas
        public async Task<IActionResult> NoticiasAtuais()
        {
            var noticias = await _context.Noticia
                .Find(_ => true)
                .SortByDescending(n => n.DataPublicacao)
                .Limit(3)
                .ToListAsync();

            return View(noticias);
        }

        // GET: Noticias Antigas - ignora as 3 últimas
        public async Task<IActionResult> NoticiasAntigas()
        {
            var noticias = await _context.Noticia
                .Find(_ => true)
                .SortByDescending(n => n.DataPublicacao)
                .Skip(3)
                .ToListAsync();

            return View(noticias);
        }

        // GET: Noticias/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticia = await _context.Noticia.Find(m => m.Id == id).FirstOrDefaultAsync();

            if (noticia == null)
            {
                return NotFound();
            }

            return View(noticia);
        }

        // GET: Noticias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Noticias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CriarNoticiaViewModel noticia)
        {
            if (ModelState.IsValid)
            {
                noticia.Id = Guid.NewGuid();

                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    noticia.IdAutor = user.Id;
                    noticia.NomeAutor = user.Nome;
                }

                noticia.DataPublicacao = DateTime.UtcNow;

                string? nomeArquivoFoto = null;

                if (noticia.Foto != null && noticia.Foto.Length > 0)
                {
                    // Gera o nome do arquivo
                    var nomeArquivo = Guid.NewGuid() + Path.GetExtension(noticia.Foto.FileName);
                    nomeArquivoFoto = Path.Combine("img", "noticias", nomeArquivo);

                    var caminhoCompleto = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", nomeArquivoFoto);

                    var pasta = Path.GetDirectoryName(caminhoCompleto);
                    if (!Directory.Exists(pasta))
                    {
                        Directory.CreateDirectory(pasta!);
                    }

                    using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                    {
                        await noticia.Foto.CopyToAsync(stream);
                    }
                }
                else
                {
                    ModelState.AddModelError("Foto", "A imagem é obrigatória.");
                    return View(noticia);
                }

                // Mapear para entidade Noticia
                var novaNoticia = new Noticia
                {
                    Id = noticia.Id,
                    Titulo = noticia.Titulo,
                    Conteudo = noticia.Conteudo,
                    Foto = nomeArquivoFoto,
                    DataPublicacao = noticia.DataPublicacao,
                    IdAutor = noticia.IdAutor,
                    NomeAutor = noticia.NomeAutor
                };

                await _context.Noticia.InsertOneAsync(novaNoticia);

                return RedirectToAction(nameof(NoticiasAtuais));
            }

            return View(noticia);
        }


        // GET: Noticias/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticia = await _context.Noticia.Find(m => m.Id == id).FirstOrDefaultAsync();
            if (noticia == null)
            {
                return NotFound();
            }

            var viewModel = new EditarNoticiaViewModel
            {
                Id = noticia.Id,
                Titulo = noticia.Titulo,
                Conteudo = noticia.Conteudo,
                Foto = noticia.Foto,
                DataEdicao = noticia.DataEdicao,
                IdEditor = noticia.IdEditor,
                NomeEditor = noticia.NomeEditor
            };

            return View(viewModel);
        }

        // POST: Noticias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditarNoticiaViewModel noticia, string imagemAtual, IFormFile Imagem)
        {
            if (id != noticia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.GetUserAsync(User);
                    string caminhoImagemSalva = imagemAtual;

                    // Se foi enviada nova imagem
                    if (Imagem != null && Imagem.Length > 0)
                    {
                        // Exclui imagem anterior, se existir
                        var imagemFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imagemAtual);
                        if (System.IO.File.Exists(imagemFilePath))
                        {
                            await Task.Run(() => System.IO.File.Delete(imagemFilePath));
                        }

                        // Salva nova imagem
                        var nomeArquivo = Guid.NewGuid() + Path.GetExtension(Imagem.FileName);
                        var novaImagemPath = Path.Combine("img", "noticias", nomeArquivo);
                        var filePathCompleto = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", novaImagemPath);

                        var pastaImagem = Path.GetDirectoryName(filePathCompleto);
                        if (!Directory.Exists(pastaImagem))
                        {
                            Directory.CreateDirectory(pastaImagem);
                        }

                        using (var stream = new FileStream(filePathCompleto, FileMode.Create))
                        {
                            await Imagem.CopyToAsync(stream);
                        }

                        caminhoImagemSalva = novaImagemPath;
                    }

                    // Atualiza notícia
                    var filter = Builders<Noticia>.Filter.Eq(n => n.Id, noticia.Id);
                    var update = Builders<Noticia>.Update
                        .Set(n => n.Titulo, noticia.Titulo)
                        .Set(n => n.Conteudo, noticia.Conteudo)
                        .Set(n => n.Foto, caminhoImagemSalva)
                        .Set(n => n.DataEdicao, DateTime.UtcNow)
                        .Set(n => n.IdEditor, user?.Id)
                        .Set(n => n.NomeEditor, user?.Nome);

                    await _context.Noticia.UpdateOneAsync(filter, update);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoticiaExists(noticia.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(NoticiasAtuais));
            }

            return View(noticia);
        }

        // GET: Noticias/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticia = await _context.Noticia.Find(m => m.Id == id).FirstOrDefaultAsync();
            if (noticia == null)
            {
                return NotFound();
            }

            return View(noticia);
        }

        // POST: Noticias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, string? imgAtual)
        {
            var noticia = await _context.Noticia.DeleteOneAsync(u => u.Id == id);
            if (!string.IsNullOrEmpty(imgAtual))
            {
                var imgCaminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imgAtual);
                //verificar se a imagem existe
                if (System.IO.File.Exists(imgCaminho))
                {
                    await Task.Run(() => System.IO.File.Delete(imgCaminho));
                }
            }
            return RedirectToAction(nameof(NoticiasAtuais));
        }

        private bool NoticiaExists(Guid id)
        {
            return _context.Noticia.Find(e => e.Id == id).Any();
        }
    }
}
