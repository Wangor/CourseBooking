// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReportController.cs" company="Bärtschi Software">
//   (c) 2015
// </copyright>
// <summary>
//   Defines the ReportController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CourseBooking.Controllers
{
    using System.IO;
    using System.Web.Mvc;
    using Services;

    /// <summary>
    /// The report controller.
    /// </summary>
    public class ReportController : Controller
    {
        /// <summary>
        /// The course report.
        /// </summary>
        /// <returns>
        /// The <see cref="FileStreamResult"/>.
        /// </returns>
        public FileStreamResult CourseReport(int courseId)
        {
            var stream = new MemoryStream();

            var report = ReportHelper.GetReportFromFile(Server.MapPath(@"~\Reports\Course.trdx"));
            report.ReportParameters["CourseId"].Value = courseId;
            var reportProcessor = new Telerik.Reporting.Processing.ReportProcessor();
            var renderingResult = reportProcessor.RenderReport("PDF", report, null);
            stream.Write(renderingResult.DocumentBytes, 0, renderingResult.DocumentBytes.Length);
            stream.Position = 0;
            return File(stream, "application/pdf", "Kursteilnehmer.pdf");
        }
    }
}