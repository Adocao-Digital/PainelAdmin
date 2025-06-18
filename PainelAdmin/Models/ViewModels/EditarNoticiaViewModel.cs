using System.ComponentModel.DataAnnotations;

namespace PainelAdmin.Models.ViewModels
{
    public class EditarNoticiaViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O título é obrigatório")]
        [Display(Name = "Título")]
        public string? Titulo { get; set; }
        [Required(ErrorMessage = "O conteúdo é obrigatório.")]
        [Display(Name = "Conteúdo")]
        public string? Conteudo { get; set; }

        public string? Foto { get; set; }
        public IFormFile? FotoUpload { get; set; }
        [Display(Name = "Editado em:")]
        public DateTime? DataEdicao { get; set; } = DateTime.UtcNow;
        public string? IdEditor { get; set; }
        [Display(Name = "Editado por:")]
        public string? NomeEditor { get; set; }

    }
}
