using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO.Compression;
using System.IO;
using System.Globalization;
using System.Reflection;

namespace PDFReporter
{
    public static class PDFReporter
    {


        public static void CreateReport<T>(IQueryable<T> report, string targetPath, string title)
        {
            FileStream fs = new FileStream(targetPath, FileMode.Create, FileAccess.ReadWrite);
            Document dc = new Document();
            int columns = report.First().GetType().GetProperties().Where(p => !p.GetMethod.IsVirtual).ToArray().Length;
            Font font;
            PdfWriter.GetInstance(dc, fs).NewPage();

            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            if (columns > 4)
            {
                font = new Font(bfTimes, 9, Font.ITALIC);
            }
            else
            {
                font = new Font(bfTimes, 12, Font.ITALIC);
            }

            dc.Open();
            using (dc)
            {
                PdfPTable table = new PdfPTable(columns);
                table.DefaultCell.Padding = 3;
                PdfPCell titleCell = new PdfPCell(new Phrase(title));
                titleCell.Colspan = columns;
                titleCell.Padding = 5;
                titleCell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                table.AddCell(titleCell);
                string date = DateTime.Now.ToString("dd-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-US"));
                PdfPCell dateCell = new PdfPCell(new Phrase("Date: " + date));
                dateCell.BackgroundColor = new BaseColor(217, 217, 217);
                dateCell.Colspan = columns;
                dateCell.Padding = 3;
                table.AddCell(dateCell);
                var props = report.First().GetType().GetProperties().Where(p => !p.GetMethod.IsVirtual);
                foreach (var prop in props)
                {
                    table.AddCell(new Phrase(prop.Name, font));
                }
                foreach (var item in report)
                {
                    var notVirtualProps = item.GetType().GetProperties().Where(p => !p.GetMethod.IsVirtual);
                    foreach (var i in notVirtualProps)
                    {
                        table.AddCell(new Phrase(GetPropValue(item, i.Name).ToString(), font));
                    }

                }

                dc.Add(table);

            }
            fs.Close();
        }

        private static Object GetPropValue(this Object obj, String name)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return null; }

                obj = info.GetValue(obj, null);
            }
            if (obj == null)
            {
                obj = "no data";
            }
            return obj;
        }


    }
}
