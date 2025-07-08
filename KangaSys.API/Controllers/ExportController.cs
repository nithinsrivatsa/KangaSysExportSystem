// <copyright file="ExportController.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.API.Controllers
{
    using KangaSys.API.Command;
    using KangaSys.Application.DTOs;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class ExportController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ExportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Export([FromBody] ExportRequest request)
        {
            var result = await _mediator.Send(new ExportReportCommand(request));
            return File(result.FileBytes, result.ContentType, result.FileName);
        }
    }
}
