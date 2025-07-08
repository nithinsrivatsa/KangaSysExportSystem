// <copyright file="ReportServiceTests.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Tests.ServicesTests
{
    using KangaSys.Application.DTOs;
    using KangaSys.Domain.Entities;
    using KangaSys.Infrastructure.Data;
    using KangaSys.Infrastructure.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Moq;

    public class ReportServiceTests
    {
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            var context = new AppDbContext(options);

            context.ClientReportData.AddRange(
            new ClientReportData
            {
                ClientId = "CLIENT-1",
                Region = "Europe",
                BusinessUnit = "Finance",
                ReportDate = DateTime.UtcNow.AddDays(-5),
                Revenue = 10000,
                Expense = 5000,
                Segment = "Retail"
            },
            new ClientReportData
            {
                ClientId = "CLIENT-2",
                Region = "Asia",
                BusinessUnit = "Sales",
                ReportDate = DateTime.UtcNow.AddDays(-10),
                Revenue = 20000,
                Expense = 8000,
                Segment = "Wholesale"
            }
            );

            context.SaveChanges();
            return context;
        }

        [Fact]
        public async Task GetReportsAsync_ShouldReturnFilteredResults()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var mockLogger = new Mock<ILogger<ReportService>>();
            var service = new ReportService(context, mockLogger.Object);

            var parameters = new ReportQueryParameters
            {
                ClientId = "CLIENT-1",
                PageNumber = 1,
                PageSize = 10
            };

            // Act
            var result = await service.GetReportsAsync(parameters);

            // Assert
            Assert.Single(result);
            Assert.Equal("CLIENT-1", result.First().ClientId);
        }
    }
}
