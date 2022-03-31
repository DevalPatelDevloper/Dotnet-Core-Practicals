using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using practical_16.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practical_16.Configuration.Entities
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "094afa8c-69e3-4103-a542-8aee12940f9a",
                    Name = Role.Admin,
                    NormalizedName = Role.Admin.ToUpper()
                },
                new IdentityRole
                {
                    Id = "9f074bba-372c-474e-81a2-92e877a73075",
                    Name = Role.User,
                    NormalizedName = Role.User.ToUpper()
                }
            );
        }
    }
}
