using InstantMessaging_IM.Application.Common.Contracts;
using InstantMessaging_IM.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace InstantMessaging_IM.Infrastructure.Services
{
    public class ApplicationUserManager : ApplicationUserManagerBase
    {
        private readonly UserStore<User, Role, InstantMessaging_IM.Infrastructure.Persistence.IdentityDbContext, int, IdentityUserClaim<int>,
                UserRole, IdentityUserLogin<int>, IdentityUserToken<int>, IdentityRoleClaim<int>> _store;
        public ApplicationUserManager(IUserStore<User> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators, IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<User>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _store = (UserStore<User, Role, InstantMessaging_IM.Infrastructure.Persistence.IdentityDbContext, int, IdentityUserClaim<int>,
            UserRole, IdentityUserLogin<int>, IdentityUserToken<int>, IdentityRoleClaim<int>>)store;
        }



        public override async Task<int> AddToRolesByIdAsync(User user, IEnumerable<int> roles)
        {
            var rolesToAdd = await _store.Context.Roles.Where(r => roles.Contains(r.Id)).ToListAsync();
            _store.Context.UserRoles.AddRange(rolesToAdd.Select(r => new UserRole { UserId = user.Id, RoleId = r.Id }));
            return await _store.Context.SaveChangesAsync();
        }
        public override async Task<IList<Role>> GetRolesWithPermissionsAsync(User user)
        {
            var rolesWithPermissions = await _store.Context.Roles
                        .Include(r => r.RolePermissions)
                        .Where(r => r.UserRoles.Any(ur => ur.UserId == user.Id)).ToListAsync();
            return rolesWithPermissions;
        }
        public override async Task<RefreshToken?> GetRefreshTokenAsync(User user)
        {
            var refreshToken = await _store.Context.RefreshTokens.FirstOrDefaultAsync(rt => rt.UserId == user.Id);
            user.UserRefreshToken = refreshToken;
            return refreshToken;
        }
        public override async Task<IdentityResult> AddRefreshTokenAsync(User user, RefreshToken refreshToken)
        {
            user.UserRefreshToken = refreshToken;
            return await UpdateAsync(user);

        }
        public override async Task DeactivetUserAsync(User user)
        {
            user.IsActive = false;
            await UpdateAsync(user);
        }
        public override async Task ActivateUserAsync(User user)
        {
            user.IsActive = true;
            await UpdateAsync(user);
        }
        public override async Task<int> UpdateUserRolesAsync(User user, IEnumerable<int> roles)
        {
            var rolesToAdd = await _store.Context.Roles.Where(r => roles.Contains(r.Id)).ToListAsync();
            var userRoles = await _store.Context.UserRoles.Where(ur => ur.UserId == user.Id).ToListAsync();
            _store.Context.UserRoles.RemoveRange(userRoles);
            _store.Context.UserRoles.AddRange(rolesToAdd.Select(r => new UserRole { UserId = user.Id, RoleId = r.Id }));
            return await _store.Context.SaveChangesAsync();
        }

    }
}
