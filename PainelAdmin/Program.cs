using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using PainelAdmin.Data;
using PainelAdmin.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ---------- Configuração EF Core (SQL Server) ----------
builder.Services.AddDbContext<PainelAdminContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PainelAdminContext")
        ?? throw new InvalidOperationException("Connection string 'PainelAdminContext' not found.")));

// ---------- MongoDB Client Singleton ----------
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var connectionString = builder.Configuration["MongoConnection:ConnectionString"];
    var isSSL = Convert.ToBoolean(builder.Configuration["MongoConnection:IsSSL"]);

    var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
    if (isSSL)
    {
        settings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };
    }
    return new MongoClient(settings);
});

// ---------- Configuração de Identity com MongoDB ----------
ContextMongodb.ConnectionString = builder.Configuration["MongoConnection:ConnectionString"];
ContextMongodb.Database = builder.Configuration["MongoConnection:Database"];
ContextMongodb.IsSSL = Convert.ToBoolean(builder.Configuration["MongoConnection:IsSSL"]);

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddMongoDbStores<ApplicationUser, ApplicationRole, string>(
        ContextMongodb.ConnectionString,
        ContextMongodb.Database);

// ---------- Configurações JWT ----------
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = jwtSettings["Key"];
var issuer = jwtSettings["Issuer"];
var audience = jwtSettings["Audience"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
        ClockSkew = TimeSpan.Zero // sem tolerância no tempo
    };

    // ---------- Validação adicional: verificar token no MongoDB ----------
    options.Events = new JwtBearerEvents
    {
        OnTokenValidated = async context =>
        {
            var mongoCollection = context.HttpContext.RequestServices.GetRequiredService<IMongoCollection<Token>>();

            if (context.SecurityToken is JwtSecurityToken jwtToken)
            {
                var tokenString = jwtToken.RawData;

                var tokenDoc = await mongoCollection
                    .Find(t => t.Jwt == tokenString && t.ExpiraEm > DateTime.UtcNow)
                    .FirstOrDefaultAsync();

                if (tokenDoc == null)
                {
                    context.Fail("Sessão inválida ou expirada.");
                }
            }
            else
            {
                context.Fail("Token inválido.");
            }
        }
    };
});

// ---------- Injeções adicionais ----------
builder.Services.AddScoped<AuthService>();
builder.Services.AddControllersWithViews();

// Injeção explícita da coleção de tokens (IMongoCollection<Token>)
builder.Services.AddScoped<IMongoCollection<Token>>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var database = client.GetDatabase(builder.Configuration["MongoConnection:Database"]);
    return database.GetCollection<Token>("Tokens");
});

// ---------- Pipeline da aplicação ----------
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//app.UseHttpsRedirection(); // pode habilitar em produção com certificado
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication(); // JWT
app.UseAuthorization();  // [Authorize] etc

// ---------- Rotas padrão MVC ----------
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
