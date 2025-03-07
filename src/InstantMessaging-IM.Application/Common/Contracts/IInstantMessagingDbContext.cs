using InstantMessaging_IM.Domain.ChatService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessaging_IM.Application.Common.Contracts;

public interface IInstantMessagingDbContext
{
    DbSet<ChatMessage> ChatMessages { get; }
    DbSet<ChatSession> ChatSessions { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
