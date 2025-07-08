// <copyright file="ClientReportDto.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Application.DTOs
{

    public class ClientReportDto
    {
        public Guid Id { get; set; }

        public string ClientId { get; set; }

        public string Region { get; set; }

        public string BusinessUnit { get; set; }

        public DateTime ReportDate { get; set; }

        public decimal Revenue { get; set; }

        public decimal Expense { get; set; }

        public string Segment { get; set; }
    }

}
