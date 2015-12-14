using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.IO.Compression;
using System.IO;
using System.Globalization;
using System.Reflection;
using System.Xml.Linq;
using InfernoDb.Data.Repository;

namespace XML
{
    public class XmlExport
    {
        private readonly string fileName = "..\\..\\Sales-by-Vendors-report.xml";

        private XElement GenerateReportXml(DateTime date, string vendor, double totalSum)
        {
            var root = new XElement("sales", 
                new XElement("sale", new XAttribute("vendor", string.Format("{0}", vendor)),
                    new XElement("summary", new XAttribute("date", string.Format("{0}", date)),
                        new XAttribute("total-sum", string.Format("{0}", totalSum)))));

            root.Add();

            return root;
        }
    }
}

