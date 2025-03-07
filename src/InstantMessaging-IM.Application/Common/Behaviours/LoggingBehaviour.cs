using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace InstantMessaging_IM.Application.Common.Behaviours;

//create pipeline logging behaviour
public class LoggingBehaviour<TRequest>:IRequestPreProcessor<TRequest> where TRequest:notnull
{
    private readonly ILogger<TRequest> _logger;
    public LoggingBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var name = typeof(TRequest).Name;
        _logger.LogInformation("InstantMessage Request: {Name} {@Request}", name, request);
        await Task.CompletedTask;
    }
}
