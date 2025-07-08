// <copyright file="ExportReportHandler.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Application.Queries
{
    using KangaSys.API.Command;
    using KangaSys.Application.DTOs;
    using KangaSys.Application.Interfaces;
    using MediatR;

    public class ExportReportHandler : IRequestHandler<ExportReportCommand, ExportReportResult>
    {
        private readonly IReportService _reportService;
        private readonly IExportServiceFactory _factory;

        public ExportReportHandler(IReportService reportService, IExportServiceFactory factory)
        {
            _reportService = reportService;
            _factory = factory;
        }

        public async Task<ExportReportResult> Handle(ExportReportCommand request, CancellationToken cancellationToken)
        {
            var data = await _reportService.GetReportsAsync(request.Request.Query);
            var service = _factory.GetService(request.Request.ExportFormat);

            var fileBytes = await service.ExportAsync(data);
            var fileName = $"Report_{DateTime.UtcNow:yyyyMMddHHmmss}.{service.FileExtension}";

            return new ExportReportResult
            {
                FileBytes = fileBytes,
                FileName = fileName,
                ContentType = service.ContentType
            };
        }
    }
}
