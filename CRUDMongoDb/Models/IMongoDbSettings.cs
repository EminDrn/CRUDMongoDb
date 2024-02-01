namespace CRUDMongoDb.Models
{
    public interface IMongoDbSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string UserCollectionName { get; set; }
        public string ProductCollectionName { get; set; }

    }
}
