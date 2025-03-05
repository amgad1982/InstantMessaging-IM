
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace InstantMessaging_IM.Domain.Identity
{
    public class User : IdentityUser<int>, IAuditableEntityBase<int, int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
      
        //public virtual RefreshToken UserRefreshToken { get; set; }
        //public virtual ICollection<UserRole> UserRoles { get; set; }

        public DateTime? Updated { get; protected set; }
        public DateTime Created { get; protected set; }
        public int UpadatedBy { get; protected set; }
        public bool IsActive { get; set; }
        public void SetCreated(int userId, DateTime created)
        {
            this.Created = created;
            this.UpadatedBy = userId;
        }

        public void SetUpdated(int userId, DateTime updated)
        {
            this.Updated = updated;
            this.UpadatedBy = userId;
        }
    }
}
