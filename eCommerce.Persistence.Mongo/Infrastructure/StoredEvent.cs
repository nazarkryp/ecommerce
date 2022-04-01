using System;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eCommerce.Persistence.Mongo.Infrastructure
{
    public class StoredEvent
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("version")]
        public int Version { get; set; }

        [BsonElement("streamId")]
        public Guid StreamId { get; set; }

        [BsonElement("data")]
        public string Data { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("timestamp")]
        public DateTime TimeStamp { get; set; }
    }
}
