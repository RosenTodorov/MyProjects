namespace MongoDbData.MongoRepository
{
    using InfernoDb.Models;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;

    public class MongoUow : IMongoUow 
    {
        private MongoDatabase database;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public MongoUow()
        {
            
        }

       

        public IMongoDbRepository<Product> Products
        {
            get { return this.GetRepository<Product>(); }
        }

        public IMongoDbRepository<Vendor> Vendors
        {
            get { return this.GetRepository<Vendor>(); }
        }

        public IMongoDbRepository<Measure> Measurs
        {
            get { return this.GetRepository<Measure>(); }
        }

        public IMongoDbRepository<Sale> Sales
        {
            get { return this.GetRepository<Sale>(); }
        }

        public IMongoDbRepository<Region> Regions
        {
            get { return this.GetRepository<Region>(); }
        }

        public IMongoDbRepository<City> Cities
        {
            get { return this.GetRepository<City>(); }
        }

        private IMongoDbRepository<T> GetRepository<T>() where T : MongoDbID
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(MongoDbRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type));
            }

            return (IMongoDbRepository<T>)this.repositories[typeof(T)];
        }





    }
}
