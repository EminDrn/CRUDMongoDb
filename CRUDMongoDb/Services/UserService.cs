using CRUDMongoDb.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CRUDMongoDb.Services
{
    public class UserService :IUserService
    {
        private readonly IMongoCollection<User> _collection;

        public UserService(IOptions<MongoDbSettings> databaseSetting)
        {
            var mongoClient = new MongoClient(databaseSetting.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSetting.Value.DatabaseName);
            _collection = mongoDatabase.GetCollection<User>(databaseSetting.Value.UserCollectionName);
        }

        public async Task AddAsync(User entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<User>.Filter.Eq("_id", ObjectId.Parse(id));
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            var filter = Builders<User>.Filter.Eq("_id", ObjectId.Parse(id));
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(string id, User entity)
        {
            var filter = Builders<User>.Filter.Eq("_id", ObjectId.Parse(id));
            await _collection.ReplaceOneAsync(filter, entity);
        }
    }
}
