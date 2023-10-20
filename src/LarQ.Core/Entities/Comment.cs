using LarQ.Core.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LarQ.Core.Entities;

public class Comment : BaseEntity
{
    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; } = default!;

    public string Content { get; set; } = string.Empty;

    public Guid EpisodeId { get; set; }
    public Episode Episode { get; set; } = default!;
}

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasOne(comment => comment.User)
            .WithMany()
            .HasForeignKey(f => f.UserId)
            .IsRequired();

        builder.Property(comment => comment.Content)
            .HasMaxLength(700)
            .IsRequired();

        builder.HasOne(comment => comment.Episode)
            .WithMany()
            .HasForeignKey(comment => comment.EpisodeId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .IsRequired();

        builder.Property(p => p.CreateAt)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.UpdatedAt)
            .ValueGeneratedOnUpdate();
    }
}