namespace MongoDbData.MongoRepository
{
    using InfernoDb.Models;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IMongoDbRepository<T> where T : MongoDbID
    {
        void Insert(T entity);

        IEnumerable<T> GetAll();

        
    }
}
