﻿using PainelAdmin.Models;
using PainelAdmin.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace PainelAdmin.Controllers
{
    public class UserController : Controller
    {
        ContextMongodb _context = new ContextMongodb();

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public UserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }



        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UsuarioCadastroViewModel model)
        {
            if (!await _roleManager.RoleExistsAsync("USER"))
            {
                await _roleManager.CreateAsync(new ApplicationRole { Name = "USER" });
            }

            if (ModelState.IsValid)
            {
                string? nomeArquivoFoto = null;

                if (model.FotoUpload != null && model.FotoUpload.Length > 0)
                {
                    var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "perfil");
                    Directory.CreateDirectory(folder);

                    nomeArquivoFoto = Guid.NewGuid() + Path.GetExtension(model.FotoUpload.FileName);
                    var caminho = Path.Combine(folder, nomeArquivoFoto);

                    using var stream = new FileStream(caminho, FileMode.Create);
                    await model.FotoUpload.CopyToAsync(stream);
                }

                var endereco = new Endereco
                {
                    Rua = model.Rua,
                    Numero = model.Numero,
                    Complemento = model.Complemento,
                    Bairro = model.Bairro,
                    Cidade = model.Cidade,
                    Estado = model.Estado,
                    CEP = model.CEP
                };

                var appUser = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.Telefone,
                    DataNascimento = model.DataNascimento,
                    Ativo = true,
                    Nome = model.Nome,
                    Endereco = endereco,
                    CPF = model.CPF,
                    Foto = nomeArquivoFoto != null ? Path.Combine("img", "perfil", nomeArquivoFoto) : null
                };

                var result = await _userManager.CreateAsync(appUser, model.Senha);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser, "USER");
                    TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";
                    return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(ApplicationRole model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var roleExistente = await _roleManager.RoleExistsAsync(model.Name);
            if (roleExistente)
            {
                ModelState.AddModelError("", "Essa role já existe.");
                return View(model);
            }

            var result = await _roleManager.CreateAsync(new ApplicationRole { Name = model.Name });
            if (result.Succeeded)
            {
                ViewBag.Message = "Role cadastrada com sucesso!";
                ModelState.Clear(); // Limpa o form
                return View(); // retorna a view com campos vazios
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        public async Task<IActionResult> Editar(string id)
        {
            var usuario = await _userManager.FindByIdAsync(id);
            if (usuario == null)
                return NotFound();

            // Garante que o endereço não seja nulo
            if (usuario.Endereco == null)
            {
                usuario.Endereco = new Endereco();
            }

            var roleAtual = (await _userManager.GetRolesAsync(usuario)).FirstOrDefault();
            var roles = _roleManager.Roles.Select(r => r.Name).ToList();

            var viewModel = new EditarUsuarioViewModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                CPF = usuario.CPF,
                Telefone = usuario.PhoneNumber,
                DataNascimento = usuario.DataNascimento,
                Foto = usuario.Foto,
                Ativo = usuario.Ativo,

                Rua = usuario.Endereco.Rua,
                Numero = usuario.Endereco.Numero,
                Complemento = usuario.Endereco.Complemento,
                Bairro = usuario.Endereco.Bairro,
                Cidade = usuario.Endereco.Cidade,
                Estado = usuario.Endereco.Estado,
                CEP = usuario.Endereco.CEP,

                NovaRole = roleAtual,
                RolesDisponiveis = roles
            };

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Editar(EditarUsuarioViewModel model, IFormFile NovaFoto)
        {
            var usuario = await _userManager.FindByIdAsync(model.Id);
            if (usuario == null)
                return NotFound();

            if (!ModelState.IsValid)
            {
                model.RolesDisponiveis = _roleManager.Roles.Select(r => r.Name).ToList();
                return View(model);
            }

            // Se uma nova foto foi enviada
            if (NovaFoto != null && NovaFoto.Length > 0)
            {
                var nomeArquivo = $"{Guid.NewGuid()}{Path.GetExtension(NovaFoto.FileName)}";
                var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "perfil");

                // Cria a pasta se ela não existir
                if (!Directory.Exists(caminhoPasta))
                    Directory.CreateDirectory(caminhoPasta);

                var caminhoDestino = Path.Combine(caminhoPasta, nomeArquivo);
                using (var stream = new FileStream(caminhoDestino, FileMode.Create))
                {
                    await NovaFoto.CopyToAsync(stream);
                }

                usuario.Foto = $"/img/perfil/{nomeArquivo}";
            }

            // Se não for enviada nova foto, mantém a antiga
            if (NovaFoto == null || NovaFoto.Length == 0)
            {
                usuario.Foto = usuario.Foto ?? "/img/perfil/default.png"; // ou mantenha o que já estava
            }

            // Atualiza dados do usuário
            usuario.Nome = model.Nome;
            usuario.Email = model.Email;
            usuario.UserName = model.Email;
            usuario.CPF = model.CPF;
            usuario.PhoneNumber = model.Telefone;
            usuario.DataNascimento = model.DataNascimento;
            usuario.Ativo = model.Ativo;
            usuario.Endereco = new Endereco
            {
                Rua = model.Rua,
                Numero = model.Numero,
                Complemento = model.Complemento,
                Bairro = model.Bairro,
                Cidade = model.Cidade,
                Estado = model.Estado,
                CEP = model.CEP
            };

            // Atualiza Role
            var rolesAtuais = await _userManager.GetRolesAsync(usuario);
            await _userManager.RemoveFromRolesAsync(usuario, rolesAtuais);
            await _userManager.AddToRoleAsync(usuario, model.NovaRole);

            // Atualiza no banco (Mongo)
            var filter = Builders<ApplicationUser>.Filter.Eq(u => u.Id, usuario.Id);
            await _context.Usuarios.ReplaceOneAsync(filter, usuario);

            TempData["MensagemSucesso"] = "Usuário atualizado com sucesso!";
            return RedirectToAction("Index");
        }




        public async Task<IActionResult> Index()
        {
            var usuarios = await _context.Usuarios.Find(_ => true).ToListAsync();
            return View(usuarios);
        }
    }
}
