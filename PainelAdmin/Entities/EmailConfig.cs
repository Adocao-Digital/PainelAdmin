namespace PainelAdmin.Entities
{
    public class EmailConfig
    {
        public string NomeRemetente { get; set; } = string.Empty;
        public string EmailRemetente { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string EnderecoServidor { get; set; } = string.Empty;
        public string Porta { get; set; } = string.Empty;
        public bool usarSsl { get; set; }
    }
}
