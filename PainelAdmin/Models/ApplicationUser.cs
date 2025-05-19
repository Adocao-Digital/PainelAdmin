using MongoDbGenericRepository.Attributes;
using AspNetCore.Identity.MongoDbCore.Models;
using System;

namespace PainelAdmin.Models
{
    [CollectionName("Usuarios")]
    public class ApplicationUser : MongoIdentityUser<string>
    {
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Foto { get; set; }
        public DateTime DataNascimento { get; set; }

        public bool Ativo { get; set; }

        public Endereco? Endereco { get; set; }
    }
}
