using Microsoft.AspNetCore.Mvc;

namespace PainelAdmin.Controllers
{
    [ApiController]
    [Route("api/session")]
    public class SessionController : ControllerBase
    {
        private readonly AuthService _authService;

        public SessionController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpGet("check")]
        public async Task<IActionResult> CheckSession()
        {
            var authHeader = Request.Headers["Authorization"].FirstOrDefault();
            if (string.IsNullOrWhiteSpace(authHeader) || !authHeader.StartsWith("Bearer "))
            {
                return Unauthorized(new { message = "Token ausente ou malformado" });
            }

            var token = authHeader.Substring("Bearer ".Length);

            var tokenDoc = await _authService.GetValidTokenAsync(token);
            if (tokenDoc == null)
            {
                return Unauthorized(new { message = "Token inválido ou expirado" });
            }

            return Ok(new
            {
                loggedIn = true,
                userId = tokenDoc.UserId,
                expiresAt = tokenDoc.ExpiraEm.ToUniversalTime()
            });
        }
    }
}
