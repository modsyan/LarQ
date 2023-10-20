using LarQ.Core.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LarQ.Core.Entities;

public class PlaylistItem : BaseEntity
{
    public Guid PlaylistId { get; set; }
    public Playlist Playlist { get; set; } = default!;

    public Guid PodcastsId { get; set; }
    public Podcast Podcasts { get; set; } = default!;
}

public class PlaylistItemConfiguration : IEntityTypeConfiguration<PlaylistItem>
{
    public void Configure(EntityTypeBuilder<PlaylistItem> builder)
    {
        builder.HasOne(item => item.Playlist)
            .WithMany(p => p.Items)
            .HasForeignKey(p => p.PlaylistId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        
        builder.HasOne(item => item.Podcasts)
            .WithMany()
            .HasForeignKey(p => p.PodcastsId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.Property(p => p.CreateAt)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.UpdatedAt)
            .ValueGeneratedOnUpdate();
    }
}