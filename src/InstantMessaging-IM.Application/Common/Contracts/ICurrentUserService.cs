using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessaging_IM.Application.Common.Contracts
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        public string[] Roles { get; }
        public string[] Permissions { get; }
        string? Ip { get; }
    }
}
