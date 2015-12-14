namespace ExcelOperating
{
    using InfernoDb.Data.Repository;
    using InfernoDb.Models;
    using Ionic.Zip;
    using System;
    using System.Data.OleDb;
    using System.Linq;

    public class ExcelAutomatic
    {
        //Usig for Parsing folder names to DateTime
        private int numberCound = 0;


        /// <summary>
        /// Retrieves data from the Excel tables and addet data to MS SQL Server
        /// </summary>
        /// <param name="zipName"></param>
        public void InsertDataInSQL(string zipFileName)
        {
            // Bourgas-Plaza-Sales-Report-20-Jul-2013.xls

            using (ZipFile zip = ZipFile.Read(zipFileName))
            {
                var nameFolder = zip.EntryFileNames;

                foreach (var file in zip)
                {
                    ZipEntry entry = zip[file.FileName];

                    using (var stream = entry.OpenReader())
                    {
                        var buffer = new byte[2048];
                        int n;
                        while ((n = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            // Names for the files in current ZipFile
                            string excelNameFile = file.FileName;

                            ConnectToExcelTables(excelNameFile,zip);

                            break;
                        }

                    }
                }
            }
        }


        private  void ConnectToExcelTables(string excelNameFile, ZipFile zip)
        {
            string provider = "Microsoft.ACE.OLEDB.12.0";
            string properties = "Excel 12.0;";

            string connectionString =
                String.Format("Provider = {0}; Data Source={1}; Extended Properties = \"{2}\"",
                                        provider, excelNameFile, properties);

            OleDbConnection connectToExcel = new OleDbConnection(connectionString);

            connectToExcel.Open();

            using (connectToExcel)
            {

                InsertExcelFromSQL(connectToExcel, zip);

                this.numberCound += 1;
            }
        }


        private  void InsertExcelFromSQL(OleDbConnection connectToExcel, ZipFile zip)
        {
            string strSQL = "SELECT * FROM [Sales$B3:E]";

            OleDbCommand cmdCommand = new OleDbCommand(strSQL, connectToExcel);

            OleDbDataReader dataExcel = cmdCommand.ExecuteReader();


            while (dataExcel.Read() && dataExcel.IsDBNull(0) == false)
            {

                DateTime date = ParsDate(zip);


                double ProductId = (double)dataExcel["ProductID"];

                double Quantity = (double)dataExcel["Quantity"];

                double UnitPrice = (double)dataExcel["Unit Price"];

                Console.WriteLine("ProductID: {0}, Quantity: {1} , UnitPrice {2}", ProductId, Quantity, UnitPrice);



                AddSaveDataSQL(date, ProductId, UnitPrice);
            }
        }

        // Parse string name Folder to Datetime
        private DateTime ParsDate(ZipFile zip)
        {
            var collectionOfFolderNames = zip.Where(z => z.IsDirectory == false).ToList();

            // Use primery parametar numberOfCount
            string nameFolder = collectionOfFolderNames[numberCound].ToString();

            string stringDate = nameFolder.Substring(10, 11);

            DateTime date = DateTime.Parse(stringDate);

            Console.WriteLine(stringDate);

            return date;
        }

        private  void AddSaveDataSQL(DateTime date, double ProductId, double UnitPrice)
        {
            var data = new UowData();

            Sale exelSales = new Sale();
            exelSales.ProductId = (int)ProductId;
            exelSales.UnitPrice = (decimal)UnitPrice;
            exelSales.DateSales = date;

            data.Sales.Add(exelSales);
            data.SaveChanges();
        }


    }
}
