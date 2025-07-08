// <copyright file="PdfExportServiceTests.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Tests.ServicesTests
{
    using KangaSys.Domain.Entities;
    using KangaSys.Infrastructure.Services;
    using Microsoft.Extensions.Logging;
    using Moq;

    public class PdfExportServiceTests
    {
        [Fact]
        public async Task ExportAsync_ShouldReturnPdfBytes()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<PdfExportService>>();
            var service = new PdfExportService(mockLogger.Object);

            var testData = new List<ClientReportData>
             {
             new ClientReportData
             {
                 ClientId = "CLIENT-1",
                 Region = "Europe",
                 BusinessUnit = "Finance",
                 Revenue = 10000,
                 Expense = 5000,
                 Segment = "Retail",
                 ReportDate = DateTime.UtcNow
             }
             };

            // Act
            var result = await service.ExportAsync(testData);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }

}
