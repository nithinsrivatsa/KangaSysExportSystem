// <copyright file="ReportService.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Infrastructure.Services
{
    using KangaSys.Application.DTOs;
    using KangaSys.Application.Interfaces;
    using KangaSys.Domain.Entities;
    using KangaSys.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    public class ReportService : IReportService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ReportService> _reportLogger;

        public ReportService(AppDbContext context, ILogger<ReportService> reportLogger)
        {
            _context = context;
            _reportLogger = reportLogger;
        }

        public async Task<IEnumerable<ClientReportData>> GetReportsAsync(ReportQueryParameters parameters)
        {
            try
            {
                var query = _context.ClientReportData.AsQueryable();

                if (!string.IsNullOrEmpty(parameters.ClientId))
                    query = query.Where(x => x.ClientId == parameters.ClientId);

                if (!string.IsNullOrEmpty(parameters.Region))
                    query = query.Where(x => x.Region == parameters.Region);

                if (!string.IsNullOrEmpty(parameters.BusinessUnit))
                    query = query.Where(x => x.BusinessUnit == parameters.BusinessUnit);

                if (parameters.FromDate.HasValue)
                    query = query.Where(x => x.ReportDate >= parameters.FromDate.Value);

                if (parameters.ToDate.HasValue)
                    query = query.Where(x => x.ReportDate <= parameters.ToDate.Value);

                if (!string.IsNullOrEmpty(parameters.SortBy))
                {
                    if (parameters.SortDescending)
                        query = query.OrderByDescending(e => EF.Property<object>(e, parameters.SortBy));
                    else
                        query = query.OrderBy(e => EF.Property<object>(e, parameters.SortBy));
                }

                return await query
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();
            }
            catch (Exception ex)
            {
                _reportLogger.LogError(ex, "An error occurred during fetching the report.");
                throw;
            }
        }
    }
}
