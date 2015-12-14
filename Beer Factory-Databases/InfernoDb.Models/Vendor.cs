namespace InfernoDb.Models
{
    using System.ComponentModel.DataAnnotations;
    using MongoDB.Bson;
    using System.ComponentModel.DataAnnotations.Schema;
    using MongoDB.Bson.Serialization.Attributes;


    public class Vendor : MongoDbID
    {   
        
        [Key]
        public int VendorId { get; set; }

        public string  VendorName { get; set; }

        [BsonIgnore]
        public virtual Product Product { get; set; }

    }
}
