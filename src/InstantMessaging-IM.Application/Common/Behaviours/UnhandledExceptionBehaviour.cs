using MediatR;
using Microsoft.Extensions.Logging;

namespace InstantMessaging_IM.Application.Common.Behaviours;
//create unhandled exception behaviour
public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;

    public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogError(ex, "InstantMessage Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);
            throw;
        }
    }
}