using LarQ.Core.Common;
using LarQ.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LarQ.Core.Entities;

public class React : BaseEntity
{
    public Guid UserId { get; set; }

    public ApplicationUser User { get; set; } = default!;

    public ReactType ReactType { get; set; }

    public Guid EpisodeId { get; set; }

    public Episode Episode { get; set; } = null!;
}

public class ReactConfiguration : IEntityTypeConfiguration<React>
{
    public void Configure(EntityTypeBuilder<React> builder)
    {
        builder.HasOne(react => react.User)
            .WithOne() // ?? TODO: FIXME 
            .HasForeignKey<React>(react => react.UserId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.Property(react => react.ReactType).IsRequired();

        builder.HasOne(react => react.Episode)
            .WithMany(episode => episode.Reacts)
            .HasForeignKey(react => react.EpisodeId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.Property(p => p.CreateAt)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.UpdatedAt)
            .ValueGeneratedOnUpdate();
    }
}