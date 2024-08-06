using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.WebForms;
using System.Net.Http.Headers;

namespace Books.API.Controllers
{
    public class ReportController : Controller
    {
        [HttpGet]
        [Route("api/reports/download")]
        public HttpResponseMessage DownloadReport()
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = "Caminho/Para/SeuRelatorio.rdlc";

            string mimeType;
            string encoding;
            string fileNameExtension;
            string[] streams;
            Warning[] warnings;

            byte[] renderedBytes;

            renderedBytes = localReport.Render(
                "PDF",
                null,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            response.Content = new ByteArrayContent(renderedBytes);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "Relatorio.pdf"
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

            return response;
        }
    }
}
