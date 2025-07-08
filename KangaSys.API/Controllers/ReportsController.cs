// <copyright file="ReportsController.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.API.Controllers
{
    using KangaSys.Application.Command;
    using KangaSys.Application.DTOs;
    using KangaSys.Application.Interfaces;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("query")]
        public async Task<IActionResult> Get([FromQuery] ReportQueryParameters parameters)
        {
            var result = await _mediator.Send(new GetReportsQuery(parameters));
            return Ok(result);
        }
    }
}
