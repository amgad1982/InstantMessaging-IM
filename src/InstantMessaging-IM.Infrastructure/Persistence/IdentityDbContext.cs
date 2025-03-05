using InstantMessaging_IM.Application.Common.Contracts;
using InstantMessaging_IM.Domain.Identity;
using InstantMessaging_IM.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InstantMessaging_IM.Infrastructure.Persistence
{
    public class IdentityDbContext : IdentityDbContext<User, Role, int,
   IdentityUserClaim<int>, // TUserClaim
   UserRole,                   // TUserRole,
   IdentityUserLogin<int>, // TUserLogin
   IdentityRoleClaim<int>, // TRoleClaim
   IdentityUserToken<int> // TUserToken
   >, IIdentityDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTimeProvider _dateTimeProvider;
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options,
                ICurrentUserService currentUserService
                , IDateTimeProvider dateTimeProvider) : base(options)
        {
            _currentUserService = currentUserService;
            _dateTimeProvider = dateTimeProvider;
        }
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        public DbSet<Permission> Permissions => Set<Permission>();
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntityBase<int, int>>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.SetCreated(int.Parse(_currentUserService.UserId), _dateTimeProvider.UTcNow);
                        break;
                    case EntityState.Modified:
                        entry.Entity.SetUpdated(int.Parse(_currentUserService.UserId), _dateTimeProvider.UTcNow);
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(),
                t => t.Namespace != null && t.Namespace.Contains("Configurations.Identity"));
        }



    }
}
