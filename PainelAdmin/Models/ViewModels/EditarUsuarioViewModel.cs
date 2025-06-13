using System.ComponentModel.DataAnnotations;

namespace PainelAdmin.Models.ViewModels
{
    public class EditarUsuarioViewModel
    {
        public string Id { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Nome Completo")]
        public string? Nome { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string? Email { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 dígitos.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O CPF deve conter apenas números.")]
        public string? CPF { get; set; }

        [Required]
        [Phone(ErrorMessage = "Telefone inválido")]
        public string? Telefone { get; set; }

        [Required]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        public string? Foto { get; set; }

        public bool Ativo { get; set; }

        // Endereço
        [Required]
        public string? Rua { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? CEP { get; set; }

        // Role
        [Required(ErrorMessage = "A role é obrigatória")]
        public string NovaRole { get; set; } = string.Empty;

        public List<string> RolesDisponiveis { get; set; } = new List<string>();
        public IFormFile? NovaFoto { get; set; }
    }
}
