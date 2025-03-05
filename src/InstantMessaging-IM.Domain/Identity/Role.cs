using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessaging_IM.Domain.Identity
{
    public class Role : IdentityRole<int>, IAuditableEntityBase<int, int>
    {
        public Role() : base() { }
        public Role(string name, string description) : base(name)
        {
            this.Description = description;

        }
        public string Description { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Permission> RolePermissions { get; set; }
      
        public DateTime? Updated { get; protected set; }
        public DateTime Created { get; protected set; }
        public int UpadatedBy { get; protected set; }

        public void AddRolePermessions(List<Permission> permissions)
        {
            //remove all existing permissions
            this.RolePermissions.Clear();
            //add new permissions
            this.RolePermissions = permissions;
        }

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
