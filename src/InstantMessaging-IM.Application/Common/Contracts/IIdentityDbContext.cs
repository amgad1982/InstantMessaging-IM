using InstantMessaging_IM.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessaging_IM.Application.Common.Contracts
{
    public interface IIdentityDbContext
    {
        DbSet<User> Users { get; }
        DbSet<Role> Roles { get; }
        DbSet<UserRole> UserRoles { get; }
        DbSet<RefreshToken> RefreshTokens { get; }
        DbSet<Permission> Permissions { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
