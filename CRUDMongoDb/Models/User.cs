﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CRUDMongoDb.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
