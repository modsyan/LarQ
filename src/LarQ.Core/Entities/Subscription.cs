using LarQ.Core.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LarQ.Core.Entities;

public class Subscription : BaseEntity
{
    public Guid UserId { get; set; }

    public ApplicationUser User { get; set; } = default!;

    public ICollection<Subscribe> Subscribes { get; set; } = new List<Subscribe>();
}

public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasOne(subscription => subscription.User)
            .WithOne(user => user.Subscription)
            .HasForeignKey<Subscription>(subscription => subscription.UserId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasMany(subscription => subscription.Subscribes)
            .WithOne(subscription => subscription.Subscription)
            .HasForeignKey(subscription => subscription.SubscriptionId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.Property(p => p.CreateAt)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.UpdatedAt)
            .ValueGeneratedOnUpdate();
    }
}