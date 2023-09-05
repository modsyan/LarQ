using System.Collections;
using LarQ.Core.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LarQ.Core.Entities;

public class Podcast : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid HostId { get; set; }

    public Host Host { get; set; } = default!;

    public Guid CoverId { get; set; }

    public UploadedFile Cover { get; set; } = default!;

    public Guid CategoryId { get; set; }

    public Category Category { get; set; } = default!;

    public ICollection<Episode> Episodes { get; set; } = new List<Episode>();

    public ICollection<Subscribe> Subscribes { get; set; } = new List<Subscribe>();
}

public class MovieConfiguration : IEntityTypeConfiguration<Podcast>
{
    public void Configure(EntityTypeBuilder<Podcast> builder)
    {
        builder.Property(movie => movie.Name)
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(movie => movie.Description)
            .HasMaxLength(2500)
            .IsRequired();

        builder.HasOne(podcast => podcast.Host)
            .WithMany(host => host.Podcasts)
            .HasForeignKey(podcast => podcast.HostId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(m => m.Cover)
            .WithOne()
            .OnDelete(DeleteBehavior.ClientCascade)
            .IsRequired();

        builder.HasOne(podcast => podcast.Category)
            .WithMany(category => category.Podcasts)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasMany(podcast => podcast.Episodes)
            .WithOne(episode => episode.Podcast)
            .HasForeignKey(episode => episode.PodcastId)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder.HasMany(podcast => podcast.Subscribes)
            .WithOne(subscribe => subscribe.Podcast)
            .HasForeignKey(subscribe => subscribe.PodcastId)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder.Property(p => p.CreateAt)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.UpdatedAt)
            .ValueGeneratedOnUpdate();
    }
}