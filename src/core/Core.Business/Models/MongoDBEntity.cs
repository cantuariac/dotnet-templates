using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Business.Models
{
    public abstract class MongoDBEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
