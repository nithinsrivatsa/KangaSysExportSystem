// <copyright file="ExportControllerTests.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Tests.ControllerTests
{
    using KangaSys.API.Controllers;
    using KangaSys.Application.DTOs;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using KangaSys.API.Command;

    public class ExportControllerTests
    {
        [Fact]
        public async Task Export_ReturnsFileContentResult_WithExpectedValues()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();

            var request = new ExportRequest
            {
                Query = new ReportQueryParameters
                {
                    FromDate = DateTime.UtcNow.AddDays(-7),
                    ToDate = DateTime.UtcNow
                },
                ExportFormat = "CSV"
            };

            var expectedResponse = new ExportReportResult
            {
                FileBytes = new byte[] { 0x01, 0x02, 0x03 },
                ContentType = "text/csv",
                FileName = "report.csv"
            };

            mockMediator
            .Setup(m => m.Send(It.IsAny<ExportReportCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResponse);

            var controller = new ExportController(mockMediator.Object);

            // Act
            var result = await controller.Export(request);

            // Assert
            var fileResult = Assert.IsType<FileContentResult>(result);
            Assert.Equal(expectedResponse.FileBytes, fileResult.FileContents);
            Assert.Equal(expectedResponse.ContentType, fileResult.ContentType);
            Assert.Equal(expectedResponse.FileName, fileResult.FileDownloadName);
        }
    }
}
