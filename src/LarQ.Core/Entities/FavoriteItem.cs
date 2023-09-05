using LarQ.Core.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LarQ.Core.Entities;

public class FavoriteItem : BaseEntity
{
    public Guid PodcastId { get; set; }
    public Podcast Podcast { get; set; } = default!;

    public Guid FavoriteId { get; set; }
    public Favorite Favorite { get; set; } = default!;
}

public class FavoriteItemConfiguration : IEntityTypeConfiguration<FavoriteItem>
{
    public void Configure(EntityTypeBuilder<FavoriteItem> builder)
    {
        builder.HasOne(favorite => favorite.Podcast)
            .WithMany()
            .HasForeignKey(favorite => favorite.PodcastId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(item => item.Favorite)
            .WithMany(list => list.Items)
            .HasForeignKey(item => item.FavoriteId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.Property(p => p.CreateAt)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.UpdatedAt)
            .ValueGeneratedOnUpdate();
    }
}