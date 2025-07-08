// <copyright file="GetReportsQuery.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Application.Queries
{
    using KangaSys.Application.Command;
    using KangaSys.Application.DTOs;
    using KangaSys.Application.Interfaces;
    using MediatR;

    public class GetReportsQueryHandler : IRequestHandler<GetReportsQuery, PaginatedResult<ClientReportDto>>
    {
        private readonly IReportService _reportService;

        public GetReportsQueryHandler(IReportService reportService)
        {
            _reportService = reportService;
        }

        public async Task<PaginatedResult<ClientReportDto>> Handle(GetReportsQuery request, CancellationToken cancellationToken)
        {
            var result = await _reportService.GetReportsAsync(request.Parameters);

            var mappedItems = result.Select(report => new ClientReportDto
            {
                Id = report.Id,
                ClientId = report.ClientId,
                Region = report.Region,
                BusinessUnit = report.BusinessUnit,
                ReportDate = report.ReportDate,
                Revenue = report.Revenue,
                Expense = report.Expense,
                Segment = report.Segment
            }).ToList();

            return new PaginatedResult<ClientReportDto>
            {
                Items = mappedItems,
                Page = request.Parameters.PageNumber,
                PageSize = request.Parameters.PageSize,
                TotalCount = mappedItems.Count
            };
        }
    }
}
