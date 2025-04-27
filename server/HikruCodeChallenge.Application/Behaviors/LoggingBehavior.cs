using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace HikruCodeChallenge.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var stopwatch = Stopwatch.StartNew();
            var response = await next();
            stopwatch.Stop();

            _logger.LogInformation(
                "Request {RequestName} processed in {ElapsedMilliseconds} ms.",
                typeof(TRequest).Name,
                stopwatch.ElapsedMilliseconds);

            return response;
        }
    }
}
