// <copyright file="IExportService.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Application.Interfaces
{
    using KangaSys.Domain.Entities;

    public interface IExportService
    {
        Task<byte[]> ExportAsync(IEnumerable<ClientReportData> data);

        string ContentType { get; }

        string FileExtension { get; }
    }
}
