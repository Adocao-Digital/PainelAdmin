using System.ComponentModel.DataAnnotations;
using System.Drawing.Imaging;

namespace Dashboard.Models
{
    public class Noticia
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Título")]
        public string? Titulo { get; set; }
        [Required]
        [Display(Name = "Conteúdo")]
        public string? Conteudo { get; set; }
        [Required]
        public string? Foto { get; set; }
        [Display(Name = "Data de Publicação")]
        public DateTime? DataPublicacao { get; set; } = DateTime.UtcNow;
        public string? IdAutor { get; set; }
        [Display(Name = "Nome do Autor")]
        public string? NomeAutor { get; set; }
        [Display(Name = "Data de Edição")]
        public DateTime? DataEdicao { get; set; }
        public string? IdEditor { get; set; }
        [Display(Name = "Nome do Editor")]
        public string? NomeEditor { get; set; }
    }
}
