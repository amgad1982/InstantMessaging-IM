using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessaging_IM.Application.Common.Behaviours.Global
{
    public class PerformanceStateBag
    {
        private readonly Stopwatch _stopwatch;
        public TimeSpan ElapsedTime => _stopwatch.Elapsed;
        public PerformanceStateBag()
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }
        public void Stop()
        {
            _stopwatch.Stop();
        }

    }
    
}
