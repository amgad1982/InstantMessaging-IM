using InstantMessaging_IM.Application.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessaging_IM.Infrastructure.Persistence
{
    public sealed class InstantMessagingDbContext:DbContext, IInstantMessagingDbContext
    {
        public InstantMessagingDbContext(DbContextOptions<InstantMessagingDbContext> options) : base(options)
        {
        }
    }
}
