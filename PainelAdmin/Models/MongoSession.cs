namespace PainelAdmin.Models
{
    public class MongoSession
    {
        public MongoDB.Bson.ObjectId Id { get; set; }
        public string Token { get; set; }
        public MongoDB.Bson.ObjectId UsuarioId { get; set; }
        public DateTime ExpiresAt { get; set; }
    }

}
