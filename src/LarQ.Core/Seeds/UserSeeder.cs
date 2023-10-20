using System.Collections.Immutable;
using LarQ.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LarQ.Core.Seeds;

public static class UserSeeder
{
    public static async void AddUserApplicationSeeder(this ModelBuilder builder)
    {
        var ph = new PasswordHasher<ApplicationUser>();

        var adminUser = new ApplicationUser
        {
            Id = Guid.NewGuid(),
            UserName = "me@admin.com",
            Email = "me@admin.com",
            Name = "Admin",
            EmailConfirmed = true,
            NormalizedUserName = "ME@ADMIN.COM",
            NormalizedEmail = "ME@ADMIN.COM",
        };
        adminUser.PasswordHash = ph.HashPassword(adminUser, "admin");


        var ownerUserId = Guid.NewGuid();
        var ownerUser = new ApplicationUser
        {
            Id = ownerUserId,
            UserName = "me@owner.com",
            Email = "me@owner.com",
            Name = "Owner",
            EmailConfirmed = true,
            NormalizedUserName = "ME@OWNER.COM",
            NormalizedEmail = "ME@OWNER.COM",
        };
        ownerUser.PasswordHash = ph.HashPassword(ownerUser, "owner");


        var ownerTwiceUserId = Guid.NewGuid();
        var ownerTwiceUser = new ApplicationUser
        {
            Id = ownerTwiceUserId,
            UserName = "twice@owner.com",
            Email = "twice@owner.com",
            Name = "Twice",
            EmailConfirmed = true,
            NormalizedUserName = "TWICe@OWNER.COM",
            NormalizedEmail = "TWICE@OWNER.COM",
        };
        ownerTwiceUser.PasswordHash = ph.HashPassword(ownerTwiceUser, "owner");

        builder.Entity<ApplicationUser>().HasData(adminUser, ownerUser, ownerTwiceUser);
    }
}