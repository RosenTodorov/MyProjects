namespace MongoDbData
{
    using MongoDB.Driver;
    using MongoDB.Bson;
    using InfernoDb.Models;
    using MongoDbData;
    using MongoDbData.MongoRepository;
    using System;
    using MongoDB.Driver.Builders;
    using System.Collections.Generic;
    using InfernoDb.Data.Repository;

    public class ExtractMongoData
    {
        public static void UpendToMsSQL ()
        {
            UowData sqlData = new UowData();
            MongoUow mongoData = new MongoUow();

            //var measure = new Measure { MeasureName = "Spas" };

            var collections = mongoData.Measurs.GetAll();

            
            using (sqlData)
            {
                foreach (var item in collections)
                {
                    string name = item.MeasureName;
                    int measureId = item.MeasureId;

                    Console.WriteLine("Name is : {0} Id is : {1}", name, measureId);


                    var sqlMeasure = new Measure
                    {
                        MeasureName = name
                    };

                    sqlData.Measures.Add(sqlMeasure);

                    sqlData.SaveChanges();


                }

            }


        }

    }
}
