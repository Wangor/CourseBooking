using System.Collections.Generic;

namespace CourseBooking.Services
{
    using System;
    using Telerik.Reporting;

    /// <summary>
    /// The report helper.
    /// </summary>
    public class ReportHelper
    {
        /// <summary>
        /// The get report from file.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <returns>
        /// The <see cref="Report"/>.
        /// </returns>
        public static Report GetReportFromFile(string path)
        {
            Report report;
            var settings = new System.Xml.XmlReaderSettings {IgnoreWhitespace = true};
            try
            {
                using (System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(path, settings))
                {
                    var xmlSerializer =
                        new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();

                    report = (Report)
                        xmlSerializer.Deserialize(xmlReader);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return report;
        }
    }
}