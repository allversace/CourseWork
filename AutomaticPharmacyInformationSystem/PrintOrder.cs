using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Table = DocumentFormat.OpenXml.Wordprocessing.Table;

namespace AutomaticPharmacyInformationSystem
{
    public abstract class PrintOrder
    {
        public static void Print(indent details, string previewLogin, int totalSum, List<order_details> OrderDetailsList)
        {
            string nowPath = @"C:\Users\artur\OneDrive\Рабочий стол\Курсовая работа\application.docx";
            string endPath = @"C:\Users\artur\OneDrive\Рабочий стол\Курсовая работа\Заказ " + details.id_indent + ".docx";
                        
            using (WordprocessingDocument wordprocessingDocument = WordprocessingDocument.CreateFromTemplate(nowPath))
            {
                if (wordprocessingDocument.MainDocumentPart != null)
                {
                    var document = wordprocessingDocument.MainDocumentPart.Document;
                                
                    var indent = document.Descendants<Text>()
                        .SingleOrDefault(x => x.Text.Contains("Indent"));
                    var account = document.Descendants<Text>()
                        .SingleOrDefault(x => x.Text.Contains("Login"));
                    var date = document.Descendants<Text>()
                        .SingleOrDefault(x => x.Text.Contains("Date"));
                    var totalPrice = document.Descendants<Text>()
                        .SingleOrDefault(x => x.Text.Contains("Price"));

                    if (indent != null)
                        indent.Text = details.id_indent.ToString();
                    if (account != null)
                        account.Text = previewLogin;
                    if (date != null)
                        date.Text = details.data_indent.ToString();
                    if (totalPrice != null)
                        totalPrice.Text = totalSum.ToString("c");
                                
                    if (wordprocessingDocument.MainDocumentPart.Document.Body != null)
                    {
                        var tables = wordprocessingDocument.MainDocumentPart.Document.Body.Descendants<Table>();

                        foreach (var table in tables)
                        {
                            int rowIndex = 1;

                            foreach (var orderDetails in OrderDetailsList)
                            {
                                if (table.Elements<TableRow>().Count() < rowIndex)
                                {
                                    var lastRow = table.Elements<TableRow>().Last();
                                    var newRow = (TableRow)lastRow.CloneNode(true);

                                    foreach (var cell in newRow.Descendants<TableCell>())
                                    {
                                        cell.Descendants<Text>().FirstOrDefault().Text = "";
                                    }
                                    table.AppendChild(newRow);
                                }

                                var row = table.Elements<TableRow>().ElementAt(rowIndex - 1);

                                row.Descendants<TableCell>().ElementAt(0).Descendants<Text>().FirstOrDefault()
                                    .Text = orderDetails.preparation.drug_name;
                                row.Descendants<TableCell>().ElementAt(1).Descendants<Text>().FirstOrDefault()
                                    .Text = orderDetails.amount.ToString();
                                row.Descendants<TableCell>().ElementAt(2).Descendants<Text>().FirstOrDefault()
                                    .Text = orderDetails.preparation.price.ToString("c");
                                row.Descendants<TableCell>().ElementAt(3).Descendants<Text>().FirstOrDefault()
                                    .Text = orderDetails.total_price.ToString("c");
                                rowIndex++;
                            }
                        }
                    }
                    wordprocessingDocument.SaveAs(endPath).Close();
                }
            }
        }
    }
}