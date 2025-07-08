// <copyright file="CsvExportService.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Infrastructure.Services
{
    using CsvHelper;
    using KangaSys.Application.Interfaces;
    using KangaSys.Domain.Entities;
    using Microsoft.Extensions.Logging;
    using System.Globalization;
    using System.Text;

    public class CsvExportService : IExportService
    {
        private readonly ILogger<CsvExportService> csvLogger;

        public CsvExportService(ILogger<CsvExportService> csvLogger)
        {
            this.csvLogger  = csvLogger;
        }

        public string ContentType => "text/csv";
        public string FileExtension => "csv";

        public async Task<byte[]> ExportAsync(IEnumerable<ClientReportData> data)
        {
            try
            {
                using var memoryStream = new MemoryStream();
                using var writer = new StreamWriter(memoryStream, Encoding.UTF8);
                using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

                await csv.WriteRecordsAsync(data);
                await writer.FlushAsync();
                return memoryStream.ToArray();
            }
            catch (Exception ex)
            {
                csvLogger.LogError(ex, "An error occurred during CSV export.");
                throw;
            }
        }
    }
}
