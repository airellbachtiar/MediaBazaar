using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Events;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Layout;
using iText.Layout.Properties;
using iText.Layout.Renderer;
using Media_Bazaar_Logic.ExportData;

namespace Media_Bazaar
{
    public static class ExportData
    {
        public static void Export(IExportDataFormat exportDataFormat)
        {
            try
            {
                //Make a file
                SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV file|*.csv|PDF file|*.pdf", ValidateNames = true };

                //Save file in designated location
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (sfd.FilterIndex == 1)
                    {
                        //Create a csv file
                        TextWriter text = new StreamWriter(new FileStream(sfd.FileName + ".csv", FileMode.Create),
                            Encoding.UTF8);

                        //Populate file content
                        text.Write(exportDataFormat.GetCSVString());

                        //Save file
                        text.Close();
                    }

                    if (sfd.FilterIndex == 2)
                    {
                        string fileLocation = sfd.FileName;
                        if (!WritePdfFile(fileLocation, exportDataFormat))
                        {
                            MessageBox.Show("Something went wrong when trying to export the data. Please try again later.");
                        }
                    }

                    MessageBox.Show("Successfully exported.");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Something went wrong when trying to export the data. Please try again later.");
            }
        }

        private static bool WritePdfFile(string fileLocation, IExportDataFormat exportDataFormat)
        {
            string csvContent = exportDataFormat.GetCSVString();
            using var reader = new StringReader(csvContent);
            string firstLine = reader.ReadLine();

            string[] columns = firstLine.Split(",");
            // First create table:
            // Table
            Table table = new Table(columns.Length, false);

            // Add the (top) columns
            foreach (string column in columns)
            {
                Cell newCell = new Cell(1,1)
                    .SetFontColor(ColorConstants.WHITE)
                    .SetBackgroundColor(new DeviceRgb(5,105,225))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph(column));
                table.AddCell(newCell);
            }

            // Add the data to the table
            int currentLine = -1;
            using (StringReader contentReader = new StringReader(csvContent))
            {
                string line;
                while ((line = contentReader.ReadLine()) != null)
                {
                    currentLine++;
                    if (currentLine == 0)
                    {
                        continue;
                    }

                    List<Cell> newCells = GetCellsFromLine(line);
                    foreach (Cell newCell in newCells)
                    {
                        table.AddCell(newCell);
                    }
                }
            }

            table.SetMarginTop(20);
            
            
            // Make PDF Document:
            PdfWriter writer = new PdfWriter(fileLocation + ".pdf");
            PdfDocument pdf = new PdfDocument(writer);
            // Change orientation:
            // PageOrientationsEventHandler eventHandler = new PageOrientationsEventHandler();
            // pdf.AddEventHandler(PdfDocumentEvent.START_PAGE, eventHandler);
            // eventHandler.SetOrientation(new PdfNumber(90));

            // Set correct width of page depending on size of table:s
            int width = 595;
            if(exportDataFormat.GetType() == typeof(ProductExportData))
            {
                width = 1000;
            }

            if (exportDataFormat.GetType() == typeof(UserExportData))
            {
                width = 1050;
            }
            PageSize pageSize = new PageSize(width, 842);
            Document document = new Document(pdf, pageSize);

            // Add logo
            Image img = new Image(ImageDataFactory
                    .Create(@"..\..\..\..\Media Bazaar Logic\img\Media Bazaar-Logo Full Color.jpeg"))
                .SetTextAlignment(TextAlignment.CENTER)
                .SetWidth(100)
                .SetHeight(100);
            document.Add(img);

            string headerName = GetHeaderName(exportDataFormat);
            if (headerName == null)
            {
                return false;
            }

            Paragraph header = new Paragraph(headerName)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(20)
                .SetMarginTop(-60);

            document.Add(header);
            LineSeparator ls = new LineSeparator(new SolidLine())
                .SetMarginTop(60);
            document.Add(ls);

            document.Add(table);
            document.Add(new Paragraph("This document has been automatically generated on: " + DateTime.Now + "."));
            
            document.Close();
            
            return true;
        }

        private static List<Cell> GetCellsFromLine(string line)
        {
            List<Cell> returnCells = new List<Cell>();

            string[] contents = line.Split(",");
            foreach (string content in contents)
            {
                Cell newCell = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .Add(new Paragraph(content));
                returnCells.Add(newCell);
            }
            
            return returnCells;
        }

        private static string GetHeaderName(IExportDataFormat exportDataFormat)
        {
            if (exportDataFormat.GetType() == typeof(StatisticsExportData))
            {
                return "Media Bazaar statistics";
            }
            if (exportDataFormat.GetType() == typeof(ProductExportData))
            {
                return "Media Bazaar products";
            }
            if (exportDataFormat.GetType() == typeof(UserExportData))
            {
                return "Media Bazaar users";
            }

            return null;
        }
    }
    
    class PageOrientationsEventHandler : IEventHandler
    {
        private PdfNumber orientation = new PdfNumber(0);

        public void SetOrientation(PdfNumber orientation)
        {
            this.orientation = orientation;
        }

        public void HandleEvent(Event currentEvent)
        {
            PdfDocumentEvent docEvent = (PdfDocumentEvent) currentEvent;
            docEvent.GetPage().Put(PdfName.Rotate, orientation);
        }
    }
}


