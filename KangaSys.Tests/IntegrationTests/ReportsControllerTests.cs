// <copyright file="ReportsControllerTests.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Tests.IntegrationTests
{
    using KangaSys.Application.DTOs;
    using Microsoft.VisualStudio.TestPlatform.TestHost;
    using System.Net;

    public class ReportsControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ReportsControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetReports_ReturnsOk()
        {
            var query = new ReportQueryParameters
            {
                ClientId = "TestClient",
                FromDate = DateTime.UtcNow.AddDays(-30),
                ToDate = DateTime.UtcNow
            };

            var url = $"/api/reports/query?ClientId={query.ClientId}&FromDate={query.FromDate:O}&ToDate={query.ToDate:O}";

            var response = await _client.GetAsync(url);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
