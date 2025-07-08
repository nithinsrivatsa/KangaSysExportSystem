// <copyright file="ExportControllerTests.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Tests.ControllerTests
{
    using KangaSys.API.Controllers;
    using KangaSys.Application.DTOs;
    using KangaSys.Application.Interfaces;
    using KangaSys.Domain.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Moq;

    public class ExportControllerTests
    {
        [Fact]
        public async Task Export_ReturnsFileContentResult_WithExpectedValues()
        {
            // Arrange
            var mockReportService = new Mock<IReportService>();
            var mockExportServiceFactory = new Mock<IExportServiceFactory>();
            var mockExportService = new Mock<IExportService>();

            var request = new ExportRequest
            {
                Query = new ReportQueryParameters
                {
                    // Fill in appropriate properties here
                    FromDate = DateTime.UtcNow.AddDays(-7),
                    ToDate = DateTime.UtcNow
                },
                ExportFormat = "CSV"
            };

            var reportData = new List<ClientReportData> { new ClientReportData() };

            mockReportService.Setup(s => s.GetReportsAsync(It.IsAny<ReportQueryParameters>()))
             .ReturnsAsync(reportData);
            var fileBytes = new byte[] { 0x01, 0x02, 0x03 };
            var contentType = "text/csv";
            var fileExtension = "csv";

            mockReportService.Setup(s => s.GetReportsAsync(request.Query))
            .ReturnsAsync(reportData);

            mockExportService.Setup(s => s.ExportAsync(reportData))
            .ReturnsAsync(fileBytes);

            mockExportService.SetupGet(s => s.ContentType).Returns(contentType);
            mockExportService.SetupGet(s => s.FileExtension).Returns(fileExtension);

            mockExportServiceFactory.Setup(f => f.GetService(request.ExportFormat))
            .Returns(mockExportService.Object);

            var controller = new ExportController(mockReportService.Object, mockExportServiceFactory.Object);

            // Act
            var result = await controller.Export(request);

            // Assert
            var fileResult = Assert.IsType<FileContentResult>(result);
            Assert.Equal(fileBytes, fileResult.FileContents);
            Assert.Equal(contentType, fileResult.ContentType);
            Assert.EndsWith(".csv", fileResult.FileDownloadName);
        }
    }
}
