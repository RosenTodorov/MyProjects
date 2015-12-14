using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML
{
    public void Import(IClinicsData data, string fileName)
        {
            this.doc.Load(fileName);
            XmlNode rootNode = this.doc.DocumentElement;
            
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var vendorName = this.GetValue(node, "vendor");
                var expenses = decimal.Parse(this.GetValue(node, "expenses-by-month"));
                var dateInfo = this.GetValue(node, "date");
                this.InportInMongo(vendorName, expenses, dateInfo);
                this.ImportInSql(data, vendorName, expenses, dateInfo);
            }
            data.SaveChanges();
        }
        private void ImportInSql(IClinicsData data, string vendorName, decimal expenses, string dateInfo)
        {
            var exists = data.Expenses.All()
                .Where(p => p.Name.Equals(vendorName))
                .FirstOrDefault();
            if (exists == null)
            {
                Exepenses expenses = new Expenses
                {
                    VendorId = Guid.NewGuid(),
                    VendorName = vendorName,
                    Expenses = expenses,
                    DateInfo = dateInfo
                };
                data.Exepenses.Add(expenses);
            }
        }
        private void InportInMongo(string vendorName, decimal expenses, string dateInfo )
        {
            var expense = mongoDb.GetCollection<BsonDocument>("expenses-by-month");
            var exists = procedures.FindAll().Where(p => p["Name"].Equals(name)).FirstOrDefault();
            if (exists == null)
            {
                Exepenses expenses = new Exepenses
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Price = price,
                    Information = information
                };
                expense.Insert<Exepenses>(procedure);
            }
        }
        private string GetValue(XmlNode node, string key)
        {
            string value = string.Empty;
            if (node[key] != null)
            {
                value = node[key].InnerText;
            }
            return value;
        }
}