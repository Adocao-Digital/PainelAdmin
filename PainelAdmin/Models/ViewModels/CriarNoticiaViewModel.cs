using System.ComponentModel.DataAnnotations;

namespace PainelAdmin.Models.ViewModels
{
    public class CriarNoticiaViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Título")]
        public string? Titulo { get; set; }
        [Required]
        [Display(Name = "Conteúdo")]
        public string? Conteudo { get; set; }
        [Display(Name = "Data de Publicação")]
        public DateTime? DataPublicacao { get; set; } = DateTime.UtcNow;
        public string? IdAutor { get; set; }
        [Display(Name = "Nome do Autor")]
        public string? NomeAutor { get; set; }

        [Required]
        public IFormFile? Foto { get; set; }
    }
}
