using System.ComponentModel.DataAnnotations;

namespace PainelAdmin.Models
{
    public class Pet
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        public string? Idade { get; set; }
        [Required]
        [Display(Name = "Espécie")]
        public string? Especie { get; set; }
        [Required]
        public string? Porte { get; set; }
        [Required]
        [Display(Name = "Raça")]
        public string? Raca { get; set; }
        [Required]
        public string? Cor { get; set; }
        [Required]
        public string? Sexo { get; set; }
        public string? Situacao { get; set; }
        public string? IdPessoa { get; set; }
        public string? Foto { get; set; }
    }
}
