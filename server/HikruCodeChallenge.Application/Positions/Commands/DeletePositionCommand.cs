using HikruCodeChallenge.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikruCodeChallenge.Application.Positions.Commands
{
    public class DeletePositionCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public class Handler : IRequestHandler<DeletePositionCommand, bool>
        {
            private readonly IPositionRepository _repository;
            private readonly ILogger<Handler> _logger;

            public Handler(IPositionRepository repository, ILogger<Handler> logger)
            {
                _repository = repository;
                _logger = logger;
            }

            public async Task<bool> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
            {
                var position = await _repository.GetByIdAsync(request.Id);

                if (position == null)
                {
                    _logger.LogWarning("Position with Id {Id} not found for deletion", request.Id);
                    return false;
                }

                await _repository.DeleteAsync(position);

                _logger.LogInformation("Deleted Position with Id {Id}", request.Id);
                return true;
            }
        }
    }
}
