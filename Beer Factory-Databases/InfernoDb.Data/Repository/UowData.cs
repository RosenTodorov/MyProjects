
namespace InfernoDb.Data.Repository
{
    using InfernoDb.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UowData : IUowData
    {
        private readonly DataContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        //Constructor UowData
        public UowData()
            : this(new DataContext())
        {

        }
        public UowData(DataContext context)
        {
            this.context = context;
        }


        // IRepository Properties

        public IRepository<Product> Products
        {
            get
            {
                return this.GetRepository<Product>();
            }
        }

        public IRepository<Vendor> Vendors
        {
            get
            {
                return this.GetRepository<Vendor>();
            }
        }

        public IRepository<Measure> Measures
        {
            get
            {
                return this.GetRepository<Measure>();
            }
        }

        public IRepository<Sale> Sales
        {
            get
            {
                return this.GetRepository<Sale>();
            }
        }

        //  Create Metods
        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }


        public IRepository<City> Cities
        {
            get { return this.GetRepository<City>(); ; }
        }

        public IRepository<Region> Regions
        {
            get { return this.GetRepository<Region>(); }
        }
    }
}
