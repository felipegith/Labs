using Labs.Aplication.Dto;
using Labs.Domain.Comand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Net;

namespace Labs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MarkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MarkDTO model, CancellationToken cancellationToken)
        {
            var comand = new AddNewMarkComand();

            var dtoToComand = comand.Maping(model.EmployeId, model.EmployerId, model.IncludedAt);

            var result = await _mediator.Send(dtoToComand, cancellationToken);

            if (result.StatusCode == HttpStatusCode.BadRequest)
                return BadRequest(result);

            return CreatedAtAction(nameof(FindAllEmployeMark), new { EmployeId = "employeId" }, result.Data);
        }

        [HttpGet]
        [Route("employer")]
        [EnableRateLimiting("fixed")]
        public async Task<IActionResult> FindAllEmployerMark(string employerId, CancellationToken cancellationToken)
        {
            var comand = new FindAllMarkEmployerComand();
            var dtoToComand = comand.Maping(employerId);

            var result = await _mediator.Send(dtoToComand, cancellationToken);

            if (result.StatusCode == HttpStatusCode.BadRequest)
                return BadRequest(result);

            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet]
        [Route("employe")]
        [EnableRateLimiting("fixed")]
        public async Task<IActionResult> FindAllEmployeMark(string employeId, CancellationToken cancellationToken)
        {
            var comand = new FindAllMarkEmployeComand();
            var dtoToComand = comand.Maping(employeId);

            var result = await _mediator.Send(dtoToComand, cancellationToken);

            if (result.StatusCode == HttpStatusCode.BadRequest)
                return BadRequest(result);

            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(result);

            return Ok(result);
        }
    }
}
