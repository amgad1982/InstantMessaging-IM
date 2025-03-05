using InstantMessaging_IM.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessaging_IM.Application.Common.Contracts
{
    public abstract class ApplicationUserManagerBase : UserManager<User>
    {
        protected ApplicationUserManagerBase(IUserStore<User> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators, IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<User>> logger)
           : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {

        }
        public abstract Task<int> AddToRolesByIdAsync(User user, IEnumerable<int> roles);
        public abstract Task<IList<Role>> GetRolesWithPermissionsAsync(User user);
        public abstract Task<RefreshToken?> GetRefreshTokenAsync(User user);
        public abstract Task<IdentityResult> AddRefreshTokenAsync(User user, RefreshToken refreshToken);
        public abstract Task DeactivetUserAsync(User user);
        public abstract Task ActivateUserAsync(User user);
        public abstract Task<int> UpdateUserRolesAsync(User user, IEnumerable<int> roles);

    }
}
