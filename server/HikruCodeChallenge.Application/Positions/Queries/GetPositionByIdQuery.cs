using HikruCodeChallenge.Application.Interfaces;
using HikruCodeChallenge.Application.Positions.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HikruCodeChallenge.Application.Positions.Queries
{
    public class GetPositionByIdQuery : IRequest<PositionDto?>
    {
        public Guid Id { get; set; }

        public class Handler : IRequestHandler<GetPositionByIdQuery, PositionDto?>
        {
            private readonly IPositionRepository _repository;
            private readonly ILogger<Handler> _logger;

            public Handler(IPositionRepository repository, ILogger<Handler> logger)
            {
                _repository = repository;
                _logger = logger;
            }

            public async Task<PositionDto?> Handle(GetPositionByIdQuery request, CancellationToken cancellationToken)
            {
                var position = await _repository.GetByIdAsync(request.Id);

                if (position == null)
                {
                    _logger.LogWarning("Position with Id {Id} not found", request.Id);
                    return null;
                }

                return new PositionDto
                {
                    Id = position.Id,
                    Title = position.Title,
                    Description = position.Description,
                    Location = position.Location,
                    Status = position.Status.ToString(),
                    RecruiterId = position.RecruiterId,
                    DepartmentId = position.DepartmentId,
                    Budget = position.Budget,
                    ClosingDate = position.ClosingDate
                };
            }
        }
    }
}
