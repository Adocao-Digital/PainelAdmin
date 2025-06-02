using Microsoft.AspNetCore.Http;

namespace PainelAdmin.Models
{
    public class RegisterDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

        // Propriedades do endereço separadas
        public string Rua { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; } = true;
    }

}
