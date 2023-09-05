using System.Collections;
using LarQ.Core.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LarQ.Core.Entities;

public class Favorite : BaseEntity
{
    public Guid UserId { get; set; }

    public ApplicationUser User { get; set; } = default!;

    public ICollection<FavoriteItem> Items { get; set; } = new List<FavoriteItem>();
}

public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
{
    public void Configure(EntityTypeBuilder<Favorite> builder)
    {
        builder.HasOne(favorite => favorite.User)
            .WithOne(user => user.Favorite)
            .HasForeignKey<Favorite>(favorite => favorite.UserId)
            .OnDelete(DeleteBehavior.Restrict).IsRequired();

        builder.HasMany(favorite => favorite.Items)
            .WithOne()
            .HasForeignKey(favorite => favorite.FavoriteId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .IsRequired();

        builder.Property(p => p.CreateAt)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.UpdatedAt)
            .ValueGeneratedOnUpdate();
    }
}