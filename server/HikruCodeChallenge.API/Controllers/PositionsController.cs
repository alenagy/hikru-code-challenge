using HikruCodeChallenge.Application.Positions.Commands;
using HikruCodeChallenge.Application.Positions.Dtos;
using HikruCodeChallenge.Application.Positions.Queries;
using HikruCodeChallenge.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HikruCodeChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PositionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePosition([FromBody] CreatePositionCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetPositionById), new { id }, null);
        }

        [HttpGet]
        public async Task<IActionResult> GetPositions()
        {
            var positions = await _mediator.Send(new GetAllPositionsQuery());
            return Ok(positions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPositionById(Guid id)
        {
            var position = await _mediator.Send(new GetPositionByIdQuery { Id = id });

            if (position == null)
                return NotFound();

            return Ok(position);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePosition(Guid id, [FromBody] UpdatePositionDto dto)
        {
            var command = new UpdatePositionCommand
            {
                Id = id,
                Title = dto.Title,
                Description = dto.Description,
                Location = dto.Location,
                Status = dto.Status,
                RecruiterId = dto.RecruiterId,
                DepartmentId = dto.DepartmentId,
                Budget = dto.Budget,
                ClosingDate = dto.ClosingDate
            };

            var result = await _mediator.Send(command);

            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosition(Guid id)
        {
            var result = await _mediator.Send(new DeletePositionCommand { Id = id });

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
