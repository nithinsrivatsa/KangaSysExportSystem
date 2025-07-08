// <copyright file="IReportService.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Application.Interfaces
{
    using KangaSys.Application.DTOs;
    using KangaSys.Domain.Entities;

    public interface IReportService
    {
        Task<IEnumerable<ClientReportData>> GetReportsAsync(ReportQueryParameters parameters);
    }
}
