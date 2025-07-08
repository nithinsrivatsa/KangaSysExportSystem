// <copyright file="ReportsController.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.API.Controllers
{
    using KangaSys.Application.DTOs;
    using KangaSys.Application.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("query")]
        public async Task<IActionResult> Get([FromQuery] ReportQueryParameters parameters)
        {
            var results = await _reportService.GetReportsAsync(parameters);
            return Ok(results);
        }
    }
}
