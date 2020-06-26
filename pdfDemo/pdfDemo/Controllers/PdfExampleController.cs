using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using IronPdf;

namespace pdfDemo.Controllers
{
    [Route("pdf")]
    [ApiController]
    public class PdfExampleController : ControllerBase
    {
        public string SaveDirectory => "C:\\Examples\\ironpdf";
        public string SaveLocation => $"{SaveDirectory}\\{Guid.NewGuid()}.pdf";

        [HttpGet]
        public IActionResult GetAll()
        {
            var renderer = new HtmlToPdf
            {
                PrintOptions =
                {
                    PaperSize = PdfPrintOptions.PdfPaperSize.A4,
                    MarginBottom = 15,
                    MarginLeft = 15,
                    MarginRight = 15,
                    MarginTop = 15,
                    CreatePdfFormsFromHtml = true
                }
            };

            var pdf = renderer.RenderHTMLFileAsPdf("Views/test.html");
            if (!Directory.Exists(SaveDirectory))
            {
                Directory.CreateDirectory(SaveDirectory);
            }
            pdf.SaveAs(SaveLocation);
            return Ok();
        }
    }
}