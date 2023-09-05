using LarQ.Core.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LarQ.Core.Entities;

public class Playlist : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    public ApplicationUser User { get; set; } = default!;

    public ICollection<PlaylistItem> Items { get; set; } = default!;
}

public class PlaylistConfiguration : IEntityTypeConfiguration<Playlist>
{
    public void Configure(EntityTypeBuilder<Playlist> builder)
    {
        builder.Property(playlist => playlist.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasOne(playlist => playlist.User)
            .WithMany()
            .HasForeignKey(playlist => playlist.UserId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasMany(playlist => playlist.Items)
            .WithOne(item => item.Playlist)
            .HasForeignKey(item => item.PlaylistId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .IsRequired();

        builder.Property(p => p.CreateAt)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.UpdatedAt)
            .ValueGeneratedOnUpdate();
    }
}