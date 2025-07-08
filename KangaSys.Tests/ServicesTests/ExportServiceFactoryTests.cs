// <copyright file="ExportServiceFactoryTests.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Tests.ServicesTests
{
    using KangaSys.Infrastructure.Services;
    using Microsoft.Extensions.Logging;
    using Moq;

    public class ExportServiceFactoryTests
    {

        [Fact]
        public void GetService_ShouldReturnCsvExportService_WhenFormatIsCsv()
        {
            // Arrange
            var mockProvider = new Mock<IServiceProvider>();
            var mockLogger = new Mock<ILogger<ExportServiceFactory>>();
            var mockCsvLogger = new Mock<ILogger<CsvExportService>>();
            var csvService = new CsvExportService(mockCsvLogger.Object);

            mockProvider.Setup(p => p.GetService(typeof(CsvExportService)))
            .Returns(csvService);

            var factory = new ExportServiceFactory(mockProvider.Object, mockLogger.Object);

            // Act
            var result = factory.GetService("csv");

            // Assert
            Assert.Equal(csvService, result);
        }

        [Fact]
        public void GetService_ShouldReturnPdfExportService_WhenFormatIsPdf()
        {
            // Arrange
            var mockProvider = new Mock<IServiceProvider>();
            var mockLogger = new Mock<ILogger<ExportServiceFactory>>();
            var mockPdfLogger = new Mock<ILogger<PdfExportService>>();
            var pdfService = new PdfExportService(mockPdfLogger.Object);

            mockProvider.Setup(p => p.GetService(typeof(PdfExportService)))
            .Returns(pdfService);

            var factory = new ExportServiceFactory(mockProvider.Object, mockLogger.Object);

            // Act
            var result = factory.GetService("pdf");

            // Assert
            Assert.Equal(pdfService, result);
        }

        [Fact]
        public void GetService_ShouldReturnJsonExportService_WhenFormatIsJson()
        {
            // Arrange
            var mockProvider = new Mock<IServiceProvider>();
            var mockLogger = new Mock<ILogger<ExportServiceFactory>>();
            var mockJsonLogger = new Mock<ILogger<JsonExportService>>();
            var jsonService = new JsonExportService(mockJsonLogger.Object);

            mockProvider.Setup(p => p.GetService(typeof(JsonExportService)))
            .Returns(jsonService);

            var factory = new ExportServiceFactory(mockProvider.Object, mockLogger.Object);

            // Act
            var result = factory.GetService("json");

            // Assert
            Assert.Equal(jsonService, result);
        }

        [Fact]
        public void GetService_ShouldThrowNotSupportedException_WhenFormatIsUnknown()
        {
            // Arrange
            var mockProvider = new Mock<IServiceProvider>();
            var mockLogger = new Mock<ILogger<ExportServiceFactory>>();
            var factory = new ExportServiceFactory(mockProvider.Object, mockLogger.Object);

            // Act & Assert
            var ex = Assert.Throws<NotSupportedException>(() => factory.GetService("xml"));
            Assert.Contains("Export format xml is not supported", ex.Message);
        }
    }
}
