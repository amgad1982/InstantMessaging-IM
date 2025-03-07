using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessaging_IM.Domain.Identity;

public class Permission : Entity<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Role> Roles { get; set; }

}
