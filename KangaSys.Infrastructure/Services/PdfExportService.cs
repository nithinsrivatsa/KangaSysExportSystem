// <copyright file="PdfExportService.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Infrastructure.Services
{
    using DinkToPdf;
    using KangaSys.Application.Interfaces;
    using KangaSys.Domain.Entities;
    using Microsoft.Extensions.Logging;
    using System.Text;

    public class PdfExportService : IExportService
    {
        private readonly ILogger<PdfExportService> pdfLogger;

        public PdfExportService(ILogger<PdfExportService> pdfLogger)
        {
            this.pdfLogger = pdfLogger;
        }

        public string ContentType => "application/pdf";
        public string FileExtension => "pdf";

        public async Task<byte[]> ExportAsync(IEnumerable<ClientReportData> data)
        {
            try
            {
                var html = GenerateHtml(data);

                var converter = new SynchronizedConverter(new PdfTools());
                var doc = new HtmlToPdfDocument()
                {
                    GlobalSettings = {
                    Orientation = Orientation.Landscape,
                    PaperSize = PaperKind.A4
                },
                    Objects = { new ObjectSettings { HtmlContent = html } }
                };

                return await Task.FromResult(converter.Convert(doc));
            }
            catch (Exception ex)
            {
                pdfLogger.LogError(ex, "An error occurred during PDF export.");
                throw;
            }
        }

        private string GenerateHtml(IEnumerable<ClientReportData> data)
        {
            try
            {
                var sb = new StringBuilder();
                sb.Append("<h2>Client Report</h2><table border='1'><tr>")
                .Append("<th>ClientId</th><th>Region</th><th>Unit</th><th>Date</th><th>Revenue</th><th>Expense</th><th>Segment</th></tr>");

                foreach (var item in data)
                {
                    sb.Append("<tr>")
                    .Append($"<td>{item.ClientId}</td>")
                    .Append($"<td>{item.Region}</td>")
                    .Append($"<td>{item.BusinessUnit}</td>")
                    .Append($"<td>{item.ReportDate:yyyy-MM-dd}</td>")
                    .Append($"<td>{item.Revenue}</td>")
                    .Append($"<td>{item.Expense}</td>")
                    .Append($"<td>{item.Segment}</td>")
                    .Append("</tr>");
                }

                sb.Append("</table>");
                return sb.ToString();
            }
            catch (Exception ex)
            {
                pdfLogger.LogError(ex, "An error occurred during HTML generation.");
                throw;
            }
        }
    }
}
