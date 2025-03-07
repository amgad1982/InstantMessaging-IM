using InstantMessaging_IM.Domain.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessaging_IM.Infrastructure.Persistence.Configurations.Identity;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(r => r.Description).IsRequired();
        //roles can have many userroles
        builder
            .HasMany(e => e.UserRoles)
            .WithOne(e => e.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();
        //roles can have many permissions
        builder
            .HasMany(e => e.RolePermissions)
            .WithMany(e => e.Roles)
            .UsingEntity<Dictionary<string, object>>(
                "RolePermission",
                e => e.HasOne<Permission>().WithMany().HasForeignKey("PermissionId"),
                e => e.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                e =>
                {
                    e.HasKey("RoleId", "PermissionId");
                });
    }
}
