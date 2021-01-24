using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MarketProxy.Model
{
    public class MarketSnapshot
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("name")]
        public string Name { get; set; }
        
        [BsonElement("date")]
        public DateTime Date { get; set; }
        
        [BsonElement("payload")]
        public string Payload { get; set; }
    }
}