// <copyright file="ReportsControllerTests.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Tests.ControllerTests
{
    using KangaSys.API.Controllers;
    using KangaSys.Application.Command;
    using KangaSys.Application.DTOs;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Moq;

    public class ReportsControllerTests
    {

        [Fact]
        public async Task Get_ReturnsOkResult_WithExpectedData()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();

            var parameters = new ReportQueryParameters
            {
                FromDate = DateTime.UtcNow.AddDays(-7),
                ToDate = DateTime.UtcNow
            };

            var expectedReports = new PaginatedResult<ClientReportDto>
            {
                Items = new List<ClientReportDto>
                 {
                 new ClientReportDto { ClientId = "Client A", Revenue = 100 },
                 new ClientReportDto { ClientId = "Client B", Revenue = 200 }
                 },
                TotalCount = 2
            };

            mockMediator
            .Setup(m => m.Send(It.IsAny<GetReportsQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedReports);

            var controller = new ReportsController(mockMediator.Object);

            // Act
            var result = await controller.Get(parameters);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualReports = Assert.IsType<PaginatedResult<ClientReportDto>>(okResult.Value);
            Assert.Equal(expectedReports.TotalCount, actualReports.TotalCount);
            Assert.Equal(expectedReports.Items.Count, actualReports.Items.Count);
        }
    }
}
