using HikruCodeChallenge.Application.Interfaces;
using HikruCodeChallenge.Application.Positions.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HikruCodeChallenge.Application.Positions.Queries
{
    public class GetAllPositionsQuery : IRequest<List<PositionDto>>
    {
        public class Handler : IRequestHandler<GetAllPositionsQuery, List<PositionDto>>
        {
            private readonly IPositionRepository _repository;
            private readonly ILogger<Handler> _logger;

            public Handler(IPositionRepository repository, ILogger<Handler> logger)
            {
                _repository = repository;
                _logger = logger;
            }

            public async Task<List<PositionDto>> Handle(GetAllPositionsQuery request, CancellationToken cancellationToken)
            {
                var positions = await _repository.GetAllAsync();

                var result = positions.Select(p => new PositionDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Location = p.Location,
                    Status = p.Status.ToString(),
                    RecruiterId = p.RecruiterId,
                    DepartmentId = p.DepartmentId,
                    Budget = p.Budget,
                    ClosingDate = p.ClosingDate
                }).ToList();

                _logger.LogInformation("Fetched {Count} positions", result.Count);

                return result;
            }
        }
    }
}