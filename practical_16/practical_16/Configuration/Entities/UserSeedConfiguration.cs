using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using practical_16.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practical_16.Configuration.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            var haser = new PasswordHasher<User>();
            builder.HasData(
                new User
                {
                    Id = "5b2546a3-3e7a-454e-ac18-52d4cae97b2f",
                    Email = "admin31@gmail.com",
                    NormalizedEmail = "ADMIN31@GMAIL.COM",
                    UserName = "admin31@gmail.com",
                    NormalizedUserName = "ADMIN31@GMAIL.COM",
                    FirstName = "Deval",
                    LastName = "Patel",
                    PasswordHash = haser.HashPassword(null, "devalp@318"),
                    EmailConfirmed = true

                },
                 new User
                 {
                     Id = "4b2546a3-3e7a-424e-ac18-52d4cae97b2f",
                     Email = "user@gmail.com",
                     NormalizedEmail = "USER@GMAIL.COM",
                     NormalizedUserName = "USER@GMAIL.COM",
                     UserName = "user@gmail.com",
                     FirstName = "system",
                     LastName = "user",
                     PasswordHash = haser.HashPassword(null, "devalp@318"),
                     EmailConfirmed = true
                 }
            );
        }
    }
}