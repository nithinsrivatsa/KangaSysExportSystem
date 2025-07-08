// <copyright file="JsonExportServiceTests.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Tests.ServicesTests
{
    using KangaSys.Domain.Entities;
    using KangaSys.Infrastructure.Services;
    using Microsoft.Extensions.Logging;
    using Moq;
    using System.Text.Json;

    public class JsonExportServiceTests
    {
        [Fact]
        public async Task ExportAsync_ShouldReturnValidJsonBytes()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<JsonExportService>>();
            var service = new JsonExportService(mockLogger.Object);

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
            var json = JsonSerializer.Deserialize<List<ClientReportData>>(result);
            Assert.Single(json);
            Assert.Equal("CLIENT-1", json[0].ClientId);
        }
    }
}
