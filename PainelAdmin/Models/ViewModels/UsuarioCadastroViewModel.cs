using System.ComponentModel.DataAnnotations;

namespace PainelAdmin.Models.ViewModels
{
    public class UsuarioCadastroViewModel
    {
        // Dados Pessoais
        [Required]
        [Display(Name = "Nome Completo")]
        public string? Nome { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O CPF deve conter apenas números.")]
        public string? CPF { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6)]
        public string? Senha { get; set; }

        [Required]
        [Phone]
        public string? Telefone { get; set; }

        [Required]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        // Endereço
        [Required]
        public string? Rua { get; set; }

        [Required]
        public string? Numero { get; set; }

        public string? Complemento { get; set; }

        [Required]
        public string? Bairro { get; set; }

        [Required]
        public string? Cidade { get; set; }

        [Required]
        public string? Estado { get; set; }
        public bool Ativo { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 8)]
        public string? CEP { get; set; }

        // Outros
        public IFormFile? FotoUpload { get; set; }
    }
}
