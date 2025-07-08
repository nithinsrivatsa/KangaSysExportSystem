// <copyright file="ReportQueryParameters.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Application.DTOs
{
    public class ReportQueryParameters
    {
        public string? ClientId { get; set; }

        public string? Region { get; set; }

        public string? BusinessUnit { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public string? SortBy { get; set; } = "ReportDate";

        public bool SortDescending { get; set; } = true;

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 20;
    }
}
