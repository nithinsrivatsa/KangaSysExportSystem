// <copyright file="ExportControllerTests.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Tests.IntegrationTests
{
    using KangaSys.Application.DTOs;
    using Microsoft.VisualStudio.TestPlatform.TestHost;
    using System.Net.Http.Json;
    using System.Net;

    public class ExportControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ExportControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Export_ReturnsFile_WhenRequestIsValid()
        {
            var request = new ExportRequest
            {
                Query = new ReportQueryParameters
                {
                    ClientId = "TestClient",
                    FromDate = DateTime.UtcNow.AddDays(-30),
                    ToDate = DateTime.UtcNow
                },
                ExportFormat = "CSV"
            };

            var response = await _client.PostAsJsonAsync("/api/export", request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("text/csv", response.Content.Headers.ContentType?.MediaType);
            Assert.True(response.Content.Headers.ContentDisposition?.FileName?.EndsWith(".csv") ?? false);
        }
    }
}
