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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using PainelAdmin.Models.ViewModels;

namespace PainelAdmin.Controllers
{
    [Route("painel/[controller]/[action]")]
    [Authorize]
    public class PetsController : Controller
    {
        ContextMongodb _context = new ContextMongodb();
        private readonly UserManager<ApplicationUser> _userManager;

        public PetsController(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }
        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> Index()
        {
            var pets = await _context.Pet.Find(_ => true).ToListAsync();

            var lista = new List<PetComDonoViewModel>();

            foreach (var pet in pets)
            {
                var dono = await _userManager.FindByIdAsync(pet.IdPessoa);
                lista.Add(new PetComDonoViewModel
                {
                    Pet = pet,
                    NomeDono = dono?.Nome ?? "Desconhecido"
                });
            }

            return View(lista);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
                return NotFound();

            var pet = await _context.Pet.Find(m => m.Id == id).FirstOrDefaultAsync();
            if (pet == null)
                return NotFound();

            var dono = await _userManager.FindByIdAsync(pet.IdPessoa);
            var viewModel = new PetComDonoViewModel
            {
                Pet = pet,
                NomeDono = dono?.Nome ?? "Desconhecido"
            };

            return View(viewModel);
        }

        public IActionResult CadastroPet()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pet pet, IFormFile Imagem)
        {
            if(!ModelState.IsValid)
            {
                Console.WriteLine("Model State é inválido.");
            }
            if (ModelState.IsValid)
            {
                string nomeArquivo = null;
                if (Imagem != null && Imagem.Length > 0)
                {
                    var folder = Path.Combine("wwwroot", "img");
                    Directory.CreateDirectory(folder);

                    nomeArquivo = Guid.NewGuid() + Path.GetExtension(Imagem.FileName);
                    var caminho = Path.Combine(folder, nomeArquivo);

                    using var stream = new FileStream(caminho, FileMode.Create);
                    await Imagem.CopyToAsync(stream);

                    pet.Foto = Path.Combine("img", nomeArquivo);
                }

                pet.Id = Guid.NewGuid();
                pet.IdPessoa = _userManager.GetUserId(User) ?? string.Empty;
                if (User.IsInRole("ADM"))
                {
                    pet.Situacao = "Adocao";
                } else
                {
                    pet.Situacao = "ComTutor";
                }

                await _context.Pet.InsertOneAsync(pet);

                if (User.IsInRole("ADM"))
                {
                    TempData["MensagemSucesso"] = "Seu pet foi cadastrado com sucesso!";
                    return RedirectToAction(nameof(Index));
                } else
                {
                    TempData["MensagemSucesso"] = "Seu pet foi cadastrado com sucesso!";
                    return RedirectToAction("MeusPets", "Pets");
                }
            }
            return View(pet);
        }

        public async Task<IActionResult> MeusPets()
        {
            var idUsuario = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(idUsuario))
                return NotFound();
            var pets = await _context.Pet.Find(m => m.IdPessoa == idUsuario).ToListAsync();
            if (pets == null || !pets.Any())
            {
                TempData["MensagemErro"] = "Você não possui nenhum pet.";
                return View(pets);
            }
            return View(pets);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            var pet = await _context.Pet.Find(m => m.Id == id).FirstOrDefaultAsync();
            if (pet == null)
                return NotFound();
            var dono = await _userManager.FindByIdAsync(pet.IdPessoa);
            if (User.IsInRole("USER") && pet.IdPessoa != dono.Id)
            {
                return Unauthorized();
            }
            if(User.IsInRole("ADM"))
                return View(pet);
            return View("UserPet");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, string imagemAtual, Pet pet, IFormFile? Imagem)
        {
            if (id != pet.Id)
                return NotFound();

            if(User.IsInRole("ADM")) {

                if (ModelState.IsValid)
                {
                    if (Imagem != null && Imagem.Length > 0)
                    {
                        var folder = Path.Combine("wwwroot", "img");
                        Directory.CreateDirectory(folder);

                        var nomeArquivo = Guid.NewGuid() + Path.GetExtension(Imagem.FileName);
                        var caminho = Path.Combine(folder, nomeArquivo);

                        using var stream = new FileStream(caminho, FileMode.Create);
                        await Imagem.CopyToAsync(stream);

                        // Deleta antiga
                        if (!string.IsNullOrEmpty(imagemAtual))
                        {
                            var antigo = Path.Combine("wwwroot", imagemAtual);
                            if (System.IO.File.Exists(antigo))
                                System.IO.File.Delete(antigo);
                        }

                        pet.Foto = Path.Combine("img", nomeArquivo);
                    }
                    else
                    {
                        pet.Foto = imagemAtual;
                    }
                }
                else
                {
                    var dono = await _userManager.FindByIdAsync(pet.IdPessoa);
                    if (pet.IdPessoa != dono.Id)
                    {
                        return Unauthorized();
                    }
                }

                await _context.Pet.ReplaceOneAsync(m => m.Id == pet.Id, pet);
                return RedirectToAction(nameof(Index));
            }
            return View(pet);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var pet = await _context.Pet.Find(m => m.Id == id).FirstOrDefaultAsync();
            if (pet == null)
                return NotFound();

            return View(pet);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, string? ImagemAtual)
        {
            await _context.Pet.DeleteOneAsync(u => u.Id == id);

            if (!string.IsNullOrEmpty(ImagemAtual))
            {
                var imagemFilePath = Path.Combine("wwwroot", ImagemAtual);
                if (System.IO.File.Exists(imagemFilePath))
                    System.IO.File.Delete(imagemFilePath);
            }
            if (User.IsInRole("ADM"))
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("MeusPets", "Pets");
        }

        private bool PetExists(Guid id)
        {
            return _context.Pet.Find(e => e.Id == id).Any();
        }
    }
}
