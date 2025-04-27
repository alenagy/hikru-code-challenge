using HikruCodeChallenge.Application.Interfaces;
using HikruCodeChallenge.Domain.Entities;
using HikruCodeChallenge.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HikruCodeChallenge.Application.Positions.Commands
{
    public class CreatePositionCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public Guid RecruiterId { get; set; }
        public Guid DepartmentId { get; set; }
        public decimal Budget { get; set; }
        public DateTime? ClosingDate { get; set; }

        public class Handler : IRequestHandler<CreatePositionCommand, Guid>
        {
            private readonly IPositionRepository _repository;
            private readonly ILogger<Handler> _logger;

            public Handler(IPositionRepository repository, ILogger<Handler> logger)
            {
                _repository = repository;
                _logger = logger;
            }

            public async Task<Guid> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
            {
                var position = new Position
                {
                    Title = request.Title,
                    Description = request.Description,
                    Location = request.Location,
                    Status = Enum.TryParse(request.Status, out PositionStatus statusEnum) ? statusEnum : PositionStatus.Draft,
                    RecruiterId = request.RecruiterId,
                    DepartmentId = request.DepartmentId,
                    Budget = request.Budget,
                    ClosingDate = request.ClosingDate
                };

                var id = await _repository.CreateAsync(position);
                _logger.LogInformation("Created new Position with Id: {Id}", id);
                return id;
            }
        }
    }
}
