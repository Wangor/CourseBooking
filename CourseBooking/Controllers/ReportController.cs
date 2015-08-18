// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReportController.cs" company="Bärtschi Software">
//   (c) 2015
// </copyright>
// <summary>
//   Defines the ReportController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using CourseBooking.Services;

namespace CourseBooking.Controllers
{
    using System.IO;
    using System.Web.Mvc;

    /// <summary>
    /// The report controller.
    /// </summary>
    public class ReportController : Controller
    {
        // GET: Report
        /// <summary>
        /// The course report.
        /// </summary>
        /// <returns>
        /// The <see cref="FileStreamResult"/>.
        /// </returns>
        public FileStreamResult CourseReport()
        {
            var stream = new MemoryStream();

            var report = ReportHelper.GetReportFromFile(Server.MapPath(@"~\Reports\Course.trdx"));
            var reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();
            var renderingResult = reportProcessor.RenderReport("PDF", report, null);
            stream.Write(renderingResult.DocumentBytes, 0, renderingResult.DocumentBytes.Length);
            stream.Position = 0;
            return File(stream, "application/pdf", "Kursteilnehmer.pdf");
        }
    }
}