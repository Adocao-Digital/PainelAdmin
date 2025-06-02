using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using MongoDB.Bson;
using PainelAdmin.Models;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly AuthService _authService;
    private readonly IMongoCollection<BsonDocument> _tokenCollection;

    public AuthController(
        UserManager<ApplicationUser> userManager,
        IMongoClient mongoClient,
        AuthService authService,
        RoleManager<ApplicationRole> roleManager)
    {
        _userManager = userManager;
        _authService = authService;
        var database = mongoClient.GetDatabase("CCZ");
        _tokenCollection = database.GetCollection<BsonDocument>("Tokens");
        _roleManager = roleManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto login)
    {
        var user = await _userManager.FindByEmailAsync(login.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, login.Senha))
            return Unauthorized("Login inválido.");

        var token = await _authService.GerarJwt(user);

        var doc = new BsonDocument {
            { "userId", user.Id },
            { "jwt", new BsonString(token) },
            { "expiraEm", DateTime.UtcNow.AddHours(2) }
        };

        await _tokenCollection.InsertOneAsync(doc);

        return Ok(new { token });
    }

    [HttpPost("register")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Register([FromForm] RegisterDto dto, IFormFile? FotoUpload)
    {
        if (!ModelState.IsValid)
        {
            var erros = ModelState
                .Where(m => m.Value.Errors.Count > 0)
                .Select(m => new {
                    Campo = m.Key,
                    Erros = m.Value.Errors.Select(e => e.ErrorMessage).ToList()
                }).ToList();

            return BadRequest(new
            {
                Sucesso = false,
                Mensagem = "Erro de validação.",
                Erros = erros
            });
        }

        if (!await _roleManager.RoleExistsAsync("USER"))
            await _roleManager.CreateAsync(new ApplicationRole { Name = "USER" });

        string? nomeArquivoFoto = null;

        if (FotoUpload != null && FotoUpload.Length > 0)
        {
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "perfil");
            Directory.CreateDirectory(folder);

            nomeArquivoFoto = Guid.NewGuid() + Path.GetExtension(FotoUpload.FileName);
            var caminho = Path.Combine(folder, nomeArquivoFoto);

            using var stream = new FileStream(caminho, FileMode.Create);
            await FotoUpload.CopyToAsync(stream);
        }

        var endereco = new Endereco
        {
            Rua = dto.Rua,
            Numero = dto.Numero,
            Bairro = dto.Bairro,
            Cidade = dto.Cidade,
            Estado = dto.Estado,
            CEP = dto.CEP
        };

        var user = new ApplicationUser
        {
            UserName = dto.Email,
            Email = dto.Email,
            Nome = dto.Nome,
            CPF = dto.CPF,
            Endereco = endereco,
            DataNascimento = dto.DataNascimento,
            PhoneNumber = dto.Telefone,
            Foto = nomeArquivoFoto != null ? Path.Combine("img", "perfil", nomeArquivoFoto) : null,
            Ativo = dto.Ativo,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, dto.Senha);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        await _userManager.AddToRoleAsync(user, "USER");

        return Ok(new { mensagem = "Usuário registrado com sucesso!" });
    }
}
