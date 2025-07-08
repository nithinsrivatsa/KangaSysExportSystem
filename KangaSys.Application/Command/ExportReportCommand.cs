// <copyright file="ExportReportCommand.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.API.Command
{

    using KangaSys.Application.DTOs;
    using MediatR;

    public class ExportReportCommand : IRequest<ExportReportResult>
    {
        public ExportRequest Request { get; set; }

        public ExportReportCommand(ExportRequest request)
        {
            Request = request;
        }
    }

}
