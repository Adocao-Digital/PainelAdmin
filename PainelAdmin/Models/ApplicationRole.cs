using System.ComponentModel.DataAnnotations;
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace PainelAdmin.Models
{
    [CollectionName("Roles")]
    public class ApplicationRole:MongoIdentityRole<string>
    {
        [Required(ErrorMessage = "O nome da role é obrigatório.")]
        [Display(Name = "Nome da Role")]
        public override string Name { get; set; } = string.Empty;
    }
}
