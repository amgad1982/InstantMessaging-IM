using InstantMessaging_IM.Application.Common.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessaging_IM.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;
            UserId = user?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "-1";
            Roles = user?.FindAll(ClaimTypes.Role).Select(x => x.Value).ToArray() ?? Array.Empty<string>();
            Permissions = user?.FindAll("permission").Select(x => x.Value).ToArray() ?? Array.Empty<string>();
            Ip = httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
        }

        public string UserId { get; }
        public string[] Roles { get; }
        public string[] Permissions { get; }
        public string? Ip { get; }
    }
}
