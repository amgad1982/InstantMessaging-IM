﻿using FastEndpoints;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessaging_IM.Application.Common.Behaviours.Global
{
    public class LoggingBehaviour : IGlobalPreProcessor
    {
        public async Task PreProcessAsync(IPreProcessorContext context, CancellationToken ct)
        {
            var logger = context.HttpContext.Resolve<ILogger>();
            var name = context.Request?.GetType().Name;
            logger.LogInformation("InstantMessage Request: {Name} {@Request}", name, context.Request);
            await Task.CompletedTask;
        }
    }
}
