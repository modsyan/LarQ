using System.Collections;
using LarQ.DataAccess.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LarQ.Core.Entities;

public class ApplicationUser : IdentityUser<Guid>, IEntity
{
    public string Name { get; set; } = string.Empty;
    public Guid FavoriteId { get; set; }
    public Favorite Favorite { get; set; } = default!;

    public Guid SubscriptionId { get; set; }
    public Subscription Subscription { get; set; } = default!;
}

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(user => user.Name).HasMaxLength(100).IsRequired();

        builder.HasOne(user => user.Favorite)
            .WithOne(favorite => favorite.User)
            .HasForeignKey<ApplicationUser>(user => user.FavoriteId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}