namespace ExcelOperating
{
    using InfernoDb.Data.Repository;
    using InfernoDb.Models;
    using Ionic.Zip;
    using System;
    using System.Data.OleDb;

    public class ExcelHandExtract
    {
        /// <summary>
        /// Extract all ZipFiles to some directory
        /// </summary>
        /// <param name="zipName"></param>
        /// <param name="folderToExtract"></param>
        public void ExtractAllFileFromZip(string zipName, string folderToExtract)
        {
            // string zipName = "D:\\Sample-Sales-Reports.zip";
            // string folderToExtract = "..\\..\\ExtractExcelFeils";

            ZipFile zip = ZipFile.Read(zipName);

            using (zip)
            {
                foreach (ZipEntry e in zip)
                {
                    e.Extract(folderToExtract);

                    Console.WriteLine("The fiels is extracted !");
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderName">For Current Directory </param>
        /// <param name="excelNameFile"></param>
        public virtual void ConnectToExcelTables( string folderName, string excelNameFile )
        {
            string directoryFile ="..\\..\\" + folderName + "\\" + excelNameFile;

            string strToParsDateTime = folderName;

            

            string provider = "Microsoft.ACE.OLEDB.12.0";
            string properties = "Excel 12.0;";

            string connectionString =
                String.Format("Provider = {0}; Data Source={1}; Extended Properties = \"{2}\"",
                                        provider, directoryFile, properties);

            OleDbConnection connectToExcel = new OleDbConnection(connectionString);

            connectToExcel.Open();

            using (connectToExcel)
            {

                InsertExcelFromSQL(connectToExcel, strToParsDateTime);

            }
        }


        private void InsertExcelFromSQL(OleDbConnection connectToExcel,string date)
        {
            string strSQL = "SELECT * FROM [Sales$B3:E]";

            OleDbCommand cmdCommand = new OleDbCommand(strSQL, connectToExcel);

            OleDbDataReader dataExcel = cmdCommand.ExecuteReader();


            while (dataExcel.Read() && dataExcel.IsDBNull(0) == false)
            {

                double ProductId = (double)dataExcel["ProductID"];

                double Quantity = (double)dataExcel["Quantity"];

                double UnitPrice = (double)dataExcel["Unit Price"];

                Console.WriteLine("ProductID: {0}, Quantity: {1} , UnitPrice {2}", ProductId, Quantity, UnitPrice);

                DateTime dateTime = DateTime.Parse(date);

                AddSaveDataSQL(dateTime, ProductId, UnitPrice);
            }
        }


        private void AddSaveDataSQL(DateTime date, double ProductId, double UnitPrice)
        {
            var data = new UowData();

            Sale exelSales = new Sale();
            exelSales.ProductId = (int)ProductId;
            exelSales.UnitPrice = (decimal)UnitPrice;
            exelSales.Date = date;

            data.Sales.Add(exelSales);
            data.SaveChanges();
        }

    }
}
