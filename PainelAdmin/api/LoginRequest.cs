using System.ComponentModel.DataAnnotations;

namespace PainelAdmin.api
{
    public class LoginRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, DataType(DataType.Password)]
        public string Senha { get; set; } = string.Empty;
    }
}
