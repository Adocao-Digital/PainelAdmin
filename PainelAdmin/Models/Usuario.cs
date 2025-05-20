using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PainelAdmin.Models
{
    public class Usuario
    {
        [Required]
        [Display(Name = "Nome Completo")]
        public string? Nome { get; set; }
        [Required]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string? Email { get; set; }
        [Required]
        [StringLength(11, ErrorMessage = "O CPF deve ter 11 dígitos.", MinimumLength = 11)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O CPF deve conter apenas números.")]
        public string? CPF { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "A senha deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        public string? Senha { get; set; }
        [Required]
        [Display(Name = "Endereço")]
        public Endereco? Endereco { get; set; }
        [Required]
        [Phone(ErrorMessage = "Telefone inválido")]
        public string? Telefone { get; set; }
        [Required]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        public string? Foto { get; set; }
        [Required]
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }
    }
}
