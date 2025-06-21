using System.ComponentModel.DataAnnotations;

namespace PainelAdmin.Models.ViewModels
{
    public class RedefinirSenhaViewModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        public string NovaSenha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmação da Nova Senha")]
        [Compare("NovaSenha", ErrorMessage = "A nova senha e a confirmação não coincidem.")]
        public string ConfirmacaoSenha { get; set; }
    }
}