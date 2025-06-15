using PainelAdmin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using PainelAdmin.Models.ViewModels;

namespace PainelAdmin.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser>? _userManager;
        private SignInManager<ApplicationUser>? _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        public IActionResult Login()
        {
            ViewBag.MensagemSucesso = TempData["MensagemSucesso"];
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([Required][EmailAddress] string email,
                                               [Required] string senha)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, senha, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError(nameof(email), "Verifique suas credenciais");
                }
            }
            return View();


        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Perfil()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            return View(user);
        }

        [Authorize]
        public async Task<IActionResult> EditarPerfil()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            var model = new UsuarioEditarViewModel
            {
                Nome = user.Nome,
                Email = user.Email,
                CPF = user.CPF,
                Sexo = user.Sexo,
                DataNascimento = user.DataNascimento,
                FotoAtual = user.Foto,
                Rua = user.Endereco?.Rua,
                Numero = user.Endereco?.Numero,
                Bairro = user.Endereco?.Bairro,
                Cidade = user.Endereco?.Cidade,
                Estado = user.Endereco?.Estado,
                CEP = user.Endereco?.CEP
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarPerfil(UsuarioEditarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            // Atualizar dados básicos
            user.Nome = model.Nome;
            user.CPF = model.CPF;
            user.Sexo = model.Sexo;
            user.DataNascimento = model.DataNascimento;

            // Atualizar endereço
            user.Endereco = new Endereco
            {
                Rua = model.Rua,
                Numero = model.Numero,
                Bairro = model.Bairro,
                Cidade = model.Cidade,
                Estado = model.Estado,
                CEP = model.CEP
            };

            // Upload de nova foto (se o usuário fizer upload)
            if (model.FotoUpload != null && model.FotoUpload.Length > 0)
            {
                var caminhoFoto = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "perfil", model.FotoUpload.FileName);

                using (var stream = new FileStream(caminhoFoto, FileMode.Create))
                {
                    await model.FotoUpload.CopyToAsync(stream);
                }

                // Salvar o caminho relativo da foto
                user.Foto = "/img/perfil/" + model.FotoUpload.FileName;
            }

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Perfil");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        [Authorize]
        public IActionResult AlterarSenha()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AlterarSenha(AlterarSenhaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            var result = await _userManager.ChangePasswordAsync(user, model.SenhaAtual, model.NovaSenha);

            if (result.Succeeded)
            {
                TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
                return RedirectToAction("Perfil");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
