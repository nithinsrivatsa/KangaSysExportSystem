// <copyright file="GetReportsQuery.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Application.Command
{
    using KangaSys.Application.DTOs;
    using MediatR;

    public class GetReportsQuery : IRequest<PaginatedResult<ClientReportDto>>
    {
        public ReportQueryParameters Parameters { get; }

        public GetReportsQuery(ReportQueryParameters parameters)
        {
            Parameters = parameters;
        }
    }
}
