using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PainelAdmin.Models
{
    public class Token
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Jwt { get; set; }
        public DateTime ExpiraEm { get; set; }
    }
}
