using PainelAdmin.Data;
using PainelAdmin.Models.ViewModels;
using MongoDB.Driver;

namespace PainelAdmin.Models
{
    public class ContextMongodb
    {
        public static string? ConnectionString { get; set; }
        public static string? Database { get; set; }
        public static bool IsSSL { get; set; }
        private IMongoDatabase _database { get; }


        public ContextMongodb()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                if (IsSSL)
                {
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                }
                var mongoCliente = new MongoClient(settings);
                _database = mongoCliente.GetDatabase(Database);

            }
            catch (Exception)
            {
                throw new Exception("Não foi possível conectar Mongodb");
            }

        }

        public IMongoCollection<Pet> Pet
        {
            get
            {
                return _database.GetCollection<Pet>("Pet");
            }
        }

        public IMongoCollection<ApplicationUser> Usuarios
        {
            get
            {
                return _database.GetCollection<ApplicationUser>("Usuarios");
            }
        }

        public IMongoCollection<Noticia> Noticia
        {
            get
            {
                return _database.GetCollection<Noticia>("Noticias");
            }
        }

        public IMongoCollection<CriarNoticiaViewModel> CriarNoticiaViewModel
        {
            get
            {
                return _database.GetCollection<CriarNoticiaViewModel>("Noticias");
            }
        }

        public IMongoCollection<EditarNoticiaViewModel> EditarNoticiaViewModel
        {
            get
            {
                return _database.GetCollection<EditarNoticiaViewModel>("Noticias");
            }
        }

        public static implicit operator ContextMongodb(PainelAdminContext v)
        {
            throw new NotImplementedException();
        }
    }
}
