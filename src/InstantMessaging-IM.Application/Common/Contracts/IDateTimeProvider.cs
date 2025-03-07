using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessaging_IM.Application.Common.Contracts;

public interface IDateTimeProvider
{
    DateTime UTcNow { get; }
}

