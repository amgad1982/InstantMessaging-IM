using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessaging_IM.Domain.Identity
{
    public class RefreshToken : Entity<int>
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
        public string ReasonRevoked { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public bool IsRevoked => Revoked != null;
        public bool IsActive => !IsRevoked && !IsExpired;
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
