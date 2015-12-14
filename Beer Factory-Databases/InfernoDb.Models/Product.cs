namespace InfernoDb.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MongoDB.Bson;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using MongoDB.Bson.Serialization.Attributes;

    public class Product : MongoDbID
    {
        private ICollection<Vendor> vendors;
        private ICollection<Measure> measure;
        private ICollection<Sale> sales;

        public Product()
        {
            this.vendors = new HashSet<Vendor>();
            this.measure = new HashSet<Measure>();
            this.sales = new HashSet<Sale>();
        }

        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal  BasePrice { get; set; }

        public DateTime DateTime { get; set; }



        public virtual ICollection<Vendor> Vendors
        {
            get { return this.vendors;}
            set { this.vendors = value; }
        }

        public virtual ICollection<Measure> Measures
        {
            get { return this.measure; }
            set { this.measure = value; }
        }

        public virtual ICollection<Sale> Sales
        {
            get { return this.sales; }
            set { this.sales = value; }
        }

    }
}
