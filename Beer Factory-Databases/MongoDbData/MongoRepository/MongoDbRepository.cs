namespace MongoDbData.MongoRepository
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Data;
    using System.Data.Linq;
    using System.Linq;
    using InfernoDb.Models;

    public class MongoDbRepository<T> : IMongoDbRepository<T> where T : MongoDbID
    {
        private MongoDatabase database;
        private MongoCollection<T> collection;

        private void GetDatabase()
        {
            var connectionString =
                "mongodb://Inferno:020364@ds033760.mongolab.com:33760/infernomongodb";


            var client = new MongoClient(connectionString);
            var server = client.GetServer();

            database = server.GetDatabase("infernomongodb");
        }


        public void Insert(T entity)
        {
            GetDatabase();
            collection = database.GetCollection<T>(typeof(T).Name);

            collection.Insert(entity);
        }


        public IEnumerable<T> GetAll()
        {
            GetDatabase();
            var bab = database.GetCollection<T>((typeof(T).Name)).FindAll();

            return bab;
        }





    }
}
