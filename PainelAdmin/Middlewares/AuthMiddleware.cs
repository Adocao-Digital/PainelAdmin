using MongoDB.Driver;
using PainelAdmin.Models;

namespace PainelAdmin.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMongoCollection<MongoSession> _sessionCollection;

        public AuthMiddleware(RequestDelegate next, IMongoClient mongoClient)
        {
            _next = next;
            _sessionCollection = mongoClient
                .GetDatabase("CCZ")
                .GetCollection<MongoSession>("sessao");
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value?.ToLower();

            // Permitir acesso às rotas de login e registro sem autenticação
            if (path == "/api/usuarios/login" || path == "/api/usuarios/registrar")
            {
                await _next(context);
                return;
            }

            var token = context.Request.Cookies["auth_token"];

            if (!string.IsNullOrEmpty(token))
            {
                var session = await _sessionCollection.Find(s =>
                    s.Token == token &&
                    s.ExpiresAt > DateTime.UtcNow
                ).FirstOrDefaultAsync();

                if (session != null)
                {
                    context.Items["UsuarioId"] = session.UsuarioId.ToString();
                    await _next(context);
                    return;
                }
            }

            // Aqui você pode decidir: ou redireciona para uma página, ou retorna 401 (mais usual em API)
            // Como é uma API, melhor retornar 401:
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Não autorizado");
        }
    }
}
