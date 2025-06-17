using System.ComponentModel.DataAnnotations;

namespace PainelAdmin.Models.ViewModels;

public class Esqueci
{
    [Required]
    [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
    [Display(Name = "E-mail")]
    public string Email { get; set; }
}
