using PainelAdmin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using PainelAdmin.Models.ViewModels;
using PainelAdmin.Services;

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

        [HttpGet]
        public IActionResult Esqueci()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Esqueci(Esqueci model, [FromServices] IEmailSender emailSender)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {

                TempData["MensagemSucesso"] = "Se o e-mail estiver cadastrado, você receberá as instruções.";
                return RedirectToAction("Login");
            }

            // Gerar token de redefinição de senha
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Montar link de redefinição
            var callbackUrl = Url.Action("RedefinirSenha", "Account", new { userId = user.Id, token = token }, protocol: Request.Scheme);

            // Enviar e-mail
            var assunto = "Redefinição de senha";
            var mensagem = $"Clique no link para redefinir sua senha: <a href='{callbackUrl}'>Redefinir senha</a>";

            await emailSender.SendEmailAsync(model.Email, assunto, "Clique no link para redefinir sua senha.", mensagem);

            TempData["MensagemSucesso"] = "Se o e-mail estiver cadastrado, você receberá as instruções.";
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult RedefinirSenha(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                TempData["MensagemErro"] = "Link de redefinição inválido.";
                return RedirectToAction("Login");
            }

            var model = new RedefinirSenhaViewModel { UserId = userId, Token = token };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RedefinirSenha(RedefinirSenhaViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                TempData["MensagemErro"] = "Usuário não encontrado.";
                return RedirectToAction("Login");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NovaSenha);
            if (result.Succeeded)
            {
                TempData["MensagemSucesso"] = "Senha redefinida com sucesso!";
                return RedirectToAction("Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }
    }
}
