// <copyright file="ExportServiceFactory.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Infrastructure.Services
{
    using KangaSys.Application.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public class ExportServiceFactory : IExportServiceFactory
    {
        private readonly IServiceProvider provider;
        private readonly ILogger<ExportServiceFactory> factoryLogger;

        public ExportServiceFactory(IServiceProvider provider, ILogger<ExportServiceFactory> factoryLogger)
        {
            this.provider = provider;
            this.factoryLogger = factoryLogger;
        }

        public IExportService GetService(string format)
        {
            try
            {
                return format.ToUpperInvariant() switch
                {
                    "CSV" => provider.GetRequiredService<CsvExportService>(),
                    "PDF" => provider.GetRequiredService<PdfExportService>(),
                    "JSON" => provider.GetRequiredService<JsonExportService>(),
                    _ => throw new NotSupportedException($"Export format {format} is not supported")
                };
            }
            catch (Exception ex)
            {
                factoryLogger.LogError(ex, "An error occurred during exporting file.");
                throw;
            }
        }
    }
}
