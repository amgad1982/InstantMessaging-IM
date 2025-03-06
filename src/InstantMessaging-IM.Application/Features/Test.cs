using FastEndpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessaging_IM.Application.Features
{
   public class Test
    {
        public async Task<string> TestMethod()
        {
            return await Task.FromResult("Hello World");
        }
    }
}
