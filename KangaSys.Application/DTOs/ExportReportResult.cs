// <copyright file="ExportReportResult.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Application.DTOs
{
    public class ExportReportResult
    {
        public byte[] FileBytes { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
    }

}
