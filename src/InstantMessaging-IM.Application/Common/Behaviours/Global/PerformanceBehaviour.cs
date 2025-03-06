using FastEndpoints;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessaging_IM.Application.Common.Behaviours.Global
{
    public class PrePerformanceBehaviour : GlobalPreProcessor<PerformanceStateBag>
    {
        public override async Task PreProcessAsync(IPreProcessorContext context, PerformanceStateBag state, CancellationToken ct)
        {
             await Task.CompletedTask;
        }
    }
    public class PostPerformanceBehaviour : GlobalPostProcessor<PerformanceStateBag>
    {
        public override async Task PostProcessAsync(IPostProcessorContext context, PerformanceStateBag state, CancellationToken ct)
        {
            var logger = context.HttpContext.Resolve<ILogger>();
            state.Stop();
            logger.LogInformation("Request: {Name} took {ElapsedMilliseconds} ms", context.Request?.GetType().Name, state.ElapsedTime.TotalMilliseconds);
            await Task.CompletedTask;
        }
    }



}
