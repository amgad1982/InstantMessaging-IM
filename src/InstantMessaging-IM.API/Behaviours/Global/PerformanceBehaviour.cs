using FastEndpoints;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessaging_IM.API.Behaviours.Global;

public class PrePerformanceBehaviour : GlobalPreProcessor<PerformanceStateBag>
{
    public override async Task PreProcessAsync(IPreProcessorContext context, PerformanceStateBag state, CancellationToken ct)
    {
         await Task.CompletedTask;
    }
}
public class PostPerformanceBehaviour(ILogger<LoggingBehaviour> logger) : GlobalPostProcessor<PerformanceStateBag>
{
    public override async Task PostProcessAsync(IPostProcessorContext context, PerformanceStateBag state, CancellationToken ct)
    {
        state.Stop();
        logger.LogInformation("Request: {Name} took {ElapsedMilliseconds} ms", context.Request?.GetType().Name, state.ElapsedTime.TotalMilliseconds);
        await Task.CompletedTask;
    }
}
