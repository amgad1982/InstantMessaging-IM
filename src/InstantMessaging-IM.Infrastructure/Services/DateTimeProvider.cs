using InstantMessaging_IM.Application.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessaging_IM.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UTcNow => DateTime.UtcNow;
}
