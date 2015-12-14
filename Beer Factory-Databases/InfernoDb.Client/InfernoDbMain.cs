namespace InfernoDb.Client
{
    using PDFReporter;
    using ExcelOperating;
    using InfernoDb.Data.Repository;
    using InfernoDb.Models;
    using Ionic.Zip;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using MongoDbData.MongoRepository;
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.Linq;
    using InfernoDb.Data;
    using System.Xml.Linq;
    using XML;

    public class InfernoDbMain
    {

        public static void Main()
        {
             UowData data = new UowData();

        var findSales = data.Sales.All();
        foreach (var sale in findSales)
        {
          
            XmlExport report = new XmlExport();


            Console.WriteLine((DateTime)sale.Date);

            report.Export((DateTime)sale.Date, sale.ProductId.ToString(), (double)sale.UnitPrice);
        
        }

        

        }
    }
}