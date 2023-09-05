using LarQ.Core.Common;
using LarQ.DataAccess.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LarQ.Core.Entities;

public class Subscribe : BaseEntity
{
    public Guid PodcastId { get; set; }
    public Podcast Podcast { get; set; } = default!;

    public Guid SubscriptionId { get; set; }
    public Subscription Subscription { get; set; }
}

public class SubscribeConfiguration : IEntityTypeConfiguration<Subscribe>
{
    public void Configure(EntityTypeBuilder<Subscribe> builder)
    {
        builder.HasOne(subscribe => subscribe.Podcast)
            .WithMany(podcast => podcast.Subscribes)
            .HasForeignKey(subscribe => subscribe.PodcastId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(subscribe => subscribe.Subscription)
            .WithMany(subscription => subscription.Subscribes)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.Property(p => p.CreateAt)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.UpdatedAt)
            .ValueGeneratedOnUpdate();
    }
}