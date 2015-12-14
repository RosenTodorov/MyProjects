using System.Xml.Linq;

public class CreatingDocumentLINQToXML
{
    public static void Main()
    {
        XNamespace vendorNs1 = "Nestle Sofia Corp.";
        XNamespace vendorNs2 = "Targovishte Bottling Company Ltd.";
        XNamespace vendorNs3 = "Zagorka Corp.";

        XNamespace dateNs1 = "20-Jul-2013";
        XNamespace dateNs2 = "21-Jul-2013";
        XNamespace dateNs3 = "22-Jul-2013";

        XNamespace sumNs1 = "54.75";
        XNamespace sumNs2 = "40.35";
        XNamespace sumNs3 = "40.60";

        XNamespace sumNs4 = "54.75";
        XNamespace sumNs5 = "40.35";
        XNamespace sumNs6 = "40.60";

        XNamespace sumNs7 = "54.75";
        XNamespace sumNs8 = "40.35";
        XNamespace sumNs9 = "40.60";



        XElement salesXml = new XElement("sales",
            new XElement("sale",
                new XAttribute("vendor", vendorNs1)),
                    new XElement("summary",
                    new XAttribute("date", dateNs1),
                    new XAttribute("total-sum", sumNs1)),
                    new XElement("summary",
                    new XAttribute("date", dateNs2),
                    new XAttribute("total-sum", sumNs2)),
                    new XElement("summary",
                    new XAttribute("date", dateNs3),
                    new XAttribute("total-sum", sumNs3)
            ),

            new XElement("sale",
                new XAttribute("vendor", vendorNs2)),
                    new XElement("summary",
                    new XAttribute("date", dateNs1),
                     new XAttribute("total-sum", sumNs4)),
                    new XElement("summary",
                    new XAttribute("date", dateNs2),
                     new XAttribute("total-sum", sumNs5)),
                    new XElement("summary",
                    new XAttribute("date", dateNs3),
                     new XAttribute("total-sum", sumNs6)
            ),

            new XElement("sale",
                new XAttribute("vendor", vendorNs3)),
                    new XElement("summary",
                    new XAttribute("date", dateNs1),
                     new XAttribute("total-sum", sumNs7)),
                    new XElement("summary",
                    new XAttribute("date", dateNs2),
                     new XAttribute("total-sum", sumNs8)),
                    new XElement("summary",
                    new XAttribute("date", dateNs3),
                     new XAttribute("total-sum", sumNs9)
                    )
        );

        System.Console.WriteLine(salesXml);

        salesXml.Save("../../Sales-by-Vendors-report.xml");
    }
}