namespace InfernoDb.Data.Repository
{
    using System;
    using InfernoDb.Models;
    public interface IUowData : IDisposable
    {

        IRepository<Vendor> Vendors { get; }
        IRepository<Measure> Measures { get; }
        IRepository<Product> Products { get; }
        IRepository<City> Cities { get; }
        IRepository<Sale> Sales { get; }
        IRepository<Region> Regions { get; }
        int SaveChanges();
    }
}
