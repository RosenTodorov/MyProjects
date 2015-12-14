namespace InfernoDb.Models
{
    using System.ComponentModel.DataAnnotations;
    using MongoDB.Bson;
    using System.ComponentModel.DataAnnotations.Schema;
    using MongoDB.Bson.Serialization.Attributes;

    public class Measure : MongoDbID
    {

        [Key]
        public int MeasureId { get; set; }

        public string  MeasureName { get; set; }

        public virtual Product Product { get; set; }
    }
}
