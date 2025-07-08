// <copyright file="ExportRequest.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Application.DTOs
{
    public class ExportRequest
    {
        public ReportQueryParameters Query { get; set; } = new();

        public string ExportFormat { get; set; } = "CSV"; // or "PDF", "JSON"
    }
}
