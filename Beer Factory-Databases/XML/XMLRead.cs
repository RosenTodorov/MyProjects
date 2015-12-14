using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLDataToDb
{
    public class XmlRead
    {
        public void Load()
        {

            // XElement rootElement = XElement.Load(@"..\\..\\Sample-Vendors-Expenses.xml");

            // Console.WriteLine(GetOutline(0, rootElement));

            XDocument doc = XDocument.Load(@"..\\..\\Sample-Vendors-Expenses.xml");

            var collection = doc.Descendants("expenses-by-month")
                .Select(vendor => new
                {
                    Vendor = vendor.Descendants("vendor")
                });

            StringBuilder result = new StringBuilder();

            int number = 1;

            foreach (var item in collection)
            {
                var some = item.Vendor.Elements();
                foreach (var a in some)
                {
                    result = result.AppendLine(a.Value);
                }
            }


            foreach (var item in collection)
            {

                var vendors = item.Vendor
                    .Select(newVendor => new
                    {
                        Header = newVendor.Attribute("name").Value,
                        Children = newVendor.Descendants("expenses")
                    });

                var sd = item.Vendor.Elements().Select(x => x.Value).ToArray();
                foreach (var vendor in vendors)
                {

                    result = result.AppendLine(vendor.Header);

                    foreach (var chill in vendor.Children)
                    {
                        result = result.AppendLine("     " + chill.Attribute("month").Value);

                        result = result.AppendLine(sd[number]);
                    }

                }

                Console.WriteLine(result.ToString());
                number += 1;
            }
        }

    }
}
