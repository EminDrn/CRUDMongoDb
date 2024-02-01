

namespace CRUDMongoDb.Models
{
    public class MongoDbSettings:IMongoDbSettings
    {
        public string ConnectionString {  get; set; }

        public string DatabaseName { get; set; }
        
        public string UserCollectionName {  get; set; }
        public string ProductCollectionName {  get; set; }


    }
}
