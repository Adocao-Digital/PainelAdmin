using MongoDbGenericRepository.Attributes;
using AspNetCore.Identity.MongoDbCore.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace PainelAdmin.Models
{
    [CollectionName("Usuarios")]
    public class ApplicationUser : MongoIdentityUser<string>
    {
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Foto { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public bool Ativo { get; set; }

        public Endereco? Endereco { get; set; }
        public string? Sexo { get; set; }
    }
}
