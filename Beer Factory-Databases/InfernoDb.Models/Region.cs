namespace InfernoDb.Models
{
    using MongoDB.Bson.Serialization.Attributes;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Region : MongoDbID
    {

        private ICollection<City> cities;
        private ICollection<Sale> sales;

        public Region()
        {
            this.cities = new HashSet<City>();
            this.sales = new HashSet<Sale>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [BsonIgnore]
        public virtual ICollection<Sale> Sales
        {
            get { return this.sales; }
            set { this.sales = value; }
        }

        [BsonIgnore]
        public virtual  ICollection<City> Cities
        {
            get { return this.cities; }
            set { this.cities = value; }
        }


    }
}
