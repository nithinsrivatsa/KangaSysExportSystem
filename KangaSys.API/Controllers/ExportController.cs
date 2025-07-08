// <copyright file="ExportController.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.API.Controllers
{
    using KangaSys.Application.DTOs;
    using KangaSys.Application.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class ExportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly IExportServiceFactory _factory;

        public ExportController(IReportService reportService, IExportServiceFactory factory)
        {
            _reportService = reportService;
            _factory = factory;
        }

        [HttpPost]
        public async Task<IActionResult> Export([FromBody] ExportRequest request)
        {
            var data = await _reportService.GetReportsAsync(request.Query);
            var service = _factory.GetService(request.ExportFormat);

            var fileBytes = await service.ExportAsync(data);
            var fileName = $"Report_{DateTime.UtcNow:yyyyMMddHHmmss}.{service.FileExtension}";

            return File(fileBytes, service.ContentType, fileName);
        }
    }
}
