// <copyright file="ReportsControllerTests.cs" company="KangaSys">
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

    public class ReportsControllerTests
    {
        [Fact]
        public async Task Get_ReturnsOkResult_WithExpectedData()
        {
            // Arrange
            var mockReportService = new Mock<IReportService>();

            var parameters = new ReportQueryParameters
            {
                FromDate = DateTime.UtcNow.AddDays(-7),
                ToDate = DateTime.UtcNow
            };

            var expectedReports = new List<ClientReportData>
            {
                new ClientReportData { ClientId = "Client A", Revenue = 100 },
                new ClientReportData { ClientId = "Client B", Revenue = 200 }
            };

            mockReportService.Setup(s => s.GetReportsAsync(parameters))
            .ReturnsAsync(expectedReports);

            var controller = new ReportsController(mockReportService.Object);

            // Act
            var result = await controller.Get(parameters);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualReports = Assert.IsAssignableFrom<IEnumerable<ClientReportData>>(okResult.Value);
            Assert.Equal(expectedReports, actualReports);
        }
    }
}
