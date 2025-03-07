using InstantMessaging_IM.Domain.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessaging_IM.Infrastructure.Persistence.Configurations.Identity;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.Property(x => x.Revoked).IsRequired(false);
        builder.Property(x => x.ReasonRevoked).IsRequired(false);
        builder.Property(x => x.ReplacedByToken).IsRequired(false);
        builder.Property(x => x.RevokedByIp).IsRequired(false);
    }
}
