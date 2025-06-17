using System.ComponentModel.DataAnnotations;

namespace PainelAdmin.Models.ViewModels
{
    public class UsuarioEditarViewModel
    {
        [Required]
        [Display(Name = "Nome Completo")]
        public string? Nome { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(11, MinimumLength = 11)]
        [Display(Name = "CPF")]
        public string? CPF { get; set; }

        public string? Sexo { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        // Endereço
        public string? Rua { get; set; }
        public string? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? CEP { get; set; }

        // Foto
        public string? FotoAtual { get; set; }

        [Display(Name = "Nova Foto de Perfil")]
        public IFormFile? FotoUpload { get; set; }
    }
}
