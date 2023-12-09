using MongoDB.Bson.Serialization.Attributes;

namespace Labs.Domain.Entities
{
    public abstract class Entity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

    }
}
