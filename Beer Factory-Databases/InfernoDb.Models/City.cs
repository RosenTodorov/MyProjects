
namespace InfernoDb.Models
{
    using MongoDB.Bson.Serialization.Attributes;
    using System.ComponentModel.DataAnnotations;
    public  class City : MongoDbID
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [BsonIgnore]
        public virtual Region Regions { get; set; }

    }
}
