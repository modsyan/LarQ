using System.ComponentModel.DataAnnotations.Schema;
using LarQ.Core.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LarQ.Core.Entities;

public class Episode : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid AudioId { get; set; }

    public UploadedFile Audio { get; set; } = default!;

    public Guid PodcastId { get; set; }

    public Podcast Podcast { get; set; } = default!;

    // [NotMapped] public virtual double Duration { get; set; } 

    // [NotMapped] public virtual double FileSize { get; set; }

    public Guid? TranscriptId { get; set; }

    public UploadedFile? Transcript { get; set; }

    public DateTime ReleaseDate { get; set; }
    public ICollection<Guest>? Guests { get; set; }

    public ICollection<React> Reacts { get; set; } = default!;
}

public class EpisodeConfiguration : IEntityTypeConfiguration<Episode>
{
    public void Configure(EntityTypeBuilder<Episode> builder)
    {
        builder.Property(episode => episode.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(episode => episode.Description)
            .HasMaxLength(700)
            .IsRequired();

        builder.HasOne(episode => episode.Audio)
            .WithMany()
            .HasForeignKey(episode => episode.AudioId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .IsRequired();

        builder.HasOne(episode => episode.Podcast)
            .WithMany(podcast => podcast.Episodes)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(episode => episode.Transcript)
            .WithMany()
            .HasForeignKey(episode => episode.TranscriptId)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder.Property(p => p.ReleaseDate)
            .ValueGeneratedOnAdd();

        builder.HasMany(episode => episode.Guests)
            .WithOne(guest => guest.Episodes)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder.HasMany(episode => episode.Reacts)
            .WithOne(react => react.Episode)
            .HasForeignKey(react => react.EpisodeId)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder.Property(p => p.CreateAt)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.UpdatedAt)
            .ValueGeneratedOnUpdate();
    }
}