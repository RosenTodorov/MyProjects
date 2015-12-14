namespace InfernoDb.Models
{
    using System.ComponentModel.DataAnnotations;
    using System;
    using MongoDB.Bson.Serialization.Attributes;

   public class Sale : MongoDbID
    {
       [Key]
        public int SaleId { get; set; }
        
       [NonSerialized]
       public int ProductId { get; set; }

       public decimal UnitPrice { get; set; }

       public decimal  Profit { get; set; }

       public DateTime? DateSales { get; set; }

       [BsonIgnore]
       public virtual Product ProduckId { get; set; }

       [BsonIgnore]
       public virtual Region Regions { get; set; }

      

    }
}
