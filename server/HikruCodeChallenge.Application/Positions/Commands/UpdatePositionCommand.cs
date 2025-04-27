using HikruCodeChallenge.Application.Interfaces;
using HikruCodeChallenge.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikruCodeChallenge.Application.Positions.Commands
{
    public class UpdatePositionCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? Status { get; set; }
        public Guid? RecruiterId { get; set; }
        public Guid? DepartmentId { get; set; }
        public decimal? Budget { get; set; }
        public DateTime? ClosingDate { get; set; }

        public class Handler : IRequestHandler<UpdatePositionCommand, bool>
        {
            private readonly IPositionRepository _repository;
            private readonly ILogger<Handler> _logger;

            public Handler(IPositionRepository repository, ILogger<Handler> logger)
            {
                _repository = repository;
                _logger = logger;
            }

            public async Task<bool> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
            {
                var position = await _repository.GetByIdAsync(request.Id);

                if (position == null)
                {
                    _logger.LogWarning("Position with Id {Id} not found for update", request.Id);
                    return false;
                }

                position.Title = string.IsNullOrWhiteSpace(request.Title) ? position.Title : request.Title;
                position.Description = string.IsNullOrWhiteSpace(request.Description) ? position.Description : request.Description;
                position.Location = string.IsNullOrWhiteSpace(request.Location) ? position.Location : request.Location;
                position.Status = Enum.TryParse(request.Status, out PositionStatus statusEnum) ? statusEnum : position.Status;
                position.RecruiterId = request.RecruiterId ?? position.RecruiterId;
                position.DepartmentId = request.DepartmentId ?? position.DepartmentId;
                position.Budget = request.Budget ?? position.Budget;
                position.ClosingDate = request.ClosingDate ?? position.ClosingDate;

                await _repository.UpdateAsync(position);

                _logger.LogInformation("Updated Position with Id {Id}", request.Id);
                return true;
            }
        }
    }
}
