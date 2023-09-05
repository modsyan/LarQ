using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LarQ.Core.Entities;

public class Host : ApplicationUser
{
    public string Bio { get; set; } = string.Empty;

    public Guid PictureId { get; set; }

    public UploadedFile Picture { get; set; } = default!;

    public Guid OwnerId { get; set; }

    public Owner Owner { get; set; } = default!;

    public ICollection<Podcast> Podcasts { get; set; } = new List<Podcast>();
}

public class HostConfiguration : IEntityTypeConfiguration<Host>
{
    public void Configure(EntityTypeBuilder<Host> builder)
    {
        builder.Property(host => host.Bio)
            .HasMaxLength(500)
            .IsRequired();

        builder.HasOne(host => host.Picture)
            .WithOne()
            .HasForeignKey<Host>(host => host.PictureId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .IsRequired();

        builder.HasOne(host => host.Owner)
            .WithMany()
            .HasForeignKey(host => host.OwnerId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasMany(host => host.Podcasts)
            .WithOne(podcast => podcast.Host)
            .HasForeignKey(podcast => podcast.HostId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .IsRequired();
    }
}