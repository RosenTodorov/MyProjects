namespace InfernoDb.Data
{
    using InfernoDb.Models;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection") 
        {

        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Vendor> Vendors { get; set; }

        public IDbSet<Measure> Measures { get; set; }

        public IDbSet<Sale> Sales { get; set; }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Region> regions { get; set; }

    }
}
