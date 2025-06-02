using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;
using PainelAdmin.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class AuthService
{
    private readonly IConfiguration _config;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMongoCollection<Token> _tokensCollection;

    public AuthService(IConfiguration config, UserManager<ApplicationUser> userManager, IMongoCollection<Token> tokensCollection)
    {
        _config = config;
        _userManager = userManager;
        _tokensCollection = tokensCollection;
    }

    public async Task<string> GerarJwt(ApplicationUser user)
    {
        var key = _config["Jwt:Key"];
        var issuer = _config["Jwt:Issuer"];
        var audience = _config["Jwt:Audience"];

        var userRoles = await _userManager.GetRolesAsync(user);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email ?? ""),
            new Claim("nome", user.Nome ?? ""),
            new Claim("cpf", user.CPF ?? "")
        };

        claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<Token?> GetValidTokenAsync(string jwt)
    {
        return await _tokensCollection
            .Find(t => t.Jwt == jwt && t.ExpiraEm > DateTime.UtcNow)
            .FirstOrDefaultAsync();
    }
}
