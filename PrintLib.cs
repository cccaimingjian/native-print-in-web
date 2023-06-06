using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace native_print_in_web
{
    internal class PrintLib
    {
        public bool PrintPdfFile(
            string printerName,
            string filePath, 
            PaperSize? paperSize = null,
            Duplex duplex = Duplex.Default)
        {
            try
            {
                var pdf = PdfiumViewer.PdfDocument.Load(filePath);
                var printer = pdf.CreatePrintDocument();
                printer.PrinterSettings.PrinterName = printerName;
                printer.PrinterSettings.Duplex = duplex;
                if (paperSize != null)
                {
                    printer.DefaultPageSettings.PaperSize = paperSize;
                }

                printer.PrintController = new StandardPrintController();
                printer.DefaultPageSettings.Color = false;
                printer.Print();
                pdf.Dispose();
                printer.Dispose();
                return true;
            }
            catch (Exception e)
            {
            }

            return false;
        }
    }
}