namespace PainelAdmin.Entities
{
    public class EmailConfig
    {
        public string NomeRemetente { get; set; }
        public string EmailRemetente { get; set; }
        public string Senha { get; set; }
        public string EnderecoServidor { get; set; }
        public string Porta { get; set; }
        public bool usarSsl { get; set; }
    }
}
