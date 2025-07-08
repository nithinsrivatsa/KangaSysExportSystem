// <copyright file="JsonExportService.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Infrastructure.Services
{
    using KangaSys.Application.Interfaces;
    using KangaSys.Domain.Entities;
    using Microsoft.Extensions.Logging;
    using System.Text.Json;

    public class JsonExportService : IExportService
    {
        private readonly ILogger<JsonExportService> jsonLogger;

        public JsonExportService(ILogger<JsonExportService> jsonLogger)
        {
            this.jsonLogger = jsonLogger;
        }

        public string ContentType => "application/json";
        public string FileExtension => "json";

        public async Task<byte[]> ExportAsync(IEnumerable<ClientReportData> data)
        {
            try
            {
                return await Task.FromResult(JsonSerializer.SerializeToUtf8Bytes(data));
            }
            catch (Exception ex)
            {
                jsonLogger.LogError(ex, "An error occurred during JSON export.");
                throw;
            }
        }
    }
}
