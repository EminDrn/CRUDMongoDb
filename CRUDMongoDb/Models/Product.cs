using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ThirdParty.Json.LitJson;

namespace CRUDMongoDb.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        
        public string Id { get; set; } =  ObjectId.GenerateNewId().ToString();

        [BsonElement("ProductName")]
        public string ProductName {  get; set; }

        public decimal ProductPrice { get; set; }

        public int ProductStock { get; set; }
    }
}
