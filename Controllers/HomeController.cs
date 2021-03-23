using Spire.Pdf;
using Spire.Pdf.Conversion;
using Spire.Pdf.Graphics;
using Spire.Pdf.HtmlConverter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace PoCSpirePDF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult PDFA()
        {
            //PdfDocument pdf = new PdfDocument(PdfConformanceLevel.Pdf_A1A);
            //PdfPageBase page = pdf.Pages.Add(PdfPageSize.A4);
            //page.Canvas.DrawImage(PdfImage.FromFile("Background.jpg"), PointF.Empty, page.GetClientSize());
            //page.Canvas.DrawString("Hello World, test PDF/A-1a!", new PdfTrueTypeFont(new Font("Arial", 20f), true), PdfBrushes.Red, new Point(10, 15));
            //pdf.SaveToFile("A-1a.pdf");
            //Specify input file path
            String inputFile = @"C:\PDFTest\4049045.pdf";
            //Specify output folder
            String outputFolder = @"C:\PDFTest\";
            //Create a PdfStandardsConverter instance, passing in the input file as a parameter
            PdfStandardsConverter converter = new PdfStandardsConverter(inputFile);

            //Convert to PdfA1A
            converter.ToPdfA1A(outputFolder + "ToPdfA1A.pdf");

            //Convert to PdfA1B
            converter.ToPdfA1B(outputFolder + "ToPdfA1B.pdf");

            //Convert to PdfA2A
            converter.ToPdfA2A(outputFolder + "ToPdfA2A.pdf");

            //Convert to PdfA2B
            converter.ToPdfA2B(outputFolder + "ToPdfA2B.pdf");

            //Convert to PdfA3A
            converter.ToPdfA3A(outputFolder + "ToPdfA3A.pdf");

            //Convert to PdfA3B
            converter.ToPdfA3B(outputFolder + "ToPdfA3B.pdf");
            return View();
        }

        public ActionResult HTMLPDF()
        {
            //Create a pdf document.
            PdfDocument doc = new PdfDocument();

            PdfPageSettings setting = new PdfPageSettings();

            setting.Size = new SizeF(1000, 1000);
            setting.Margins = new Spire.Pdf.Graphics.PdfMargins(20);

            PdfHtmlLayoutFormat htmlLayoutFormat = new PdfHtmlLayoutFormat();
            htmlLayoutFormat.IsWaiting = true;

            doc.
            String url = "https://www.wikipedia.org/";

            Thread thread = new Thread(() =>
            { doc.LoadFromHTML(url, false, false, false, setting, htmlLayoutFormat); });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            //Save pdf file.
            doc.SaveToFile(@"C:\PDFTest\output-wiki.pdf");
            doc.Close();
            //Launching the Pdf file.
            //System.Diagnostics.Process.Start("output-wiki.pdf");

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}