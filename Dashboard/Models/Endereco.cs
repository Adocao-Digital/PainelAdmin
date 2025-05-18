using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
    public class Endereco
    {
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

        [Required]
        [StringLength(9, ErrorMessage = "O CEP deve ter 8 dígitos.", MinimumLength = 8)]
        public string? CEP { get; set; }
    }
}
