using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models.ViewModels
{
    public class PetComDonoViewModel
    {
        public Pet Pet { get; set; }
        [Display(Name = "Dono")]
        public string NomeDono { get; set; }
    }
}
