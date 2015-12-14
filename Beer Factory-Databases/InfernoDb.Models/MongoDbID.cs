namespace InfernoDb.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MongoDbID
    {
        [BsonId]
        [NotMapped]
        public ObjectId MongoId { get; set; }
    }
}
