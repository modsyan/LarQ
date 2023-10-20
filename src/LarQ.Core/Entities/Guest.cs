using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChustaSoft.Services.StaticData.Models;
using LarQ.Core.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LarQ.Core.Entities;

public class Guest : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Nationality { get; set; } = string.Empty;
    // public Country Nationality { get; set; }

    public Guid PictureId { get; set; }

    public UploadedFile Picture { get; set; } = default!;

    public Guid EpisodesId { get; set; }

    public Episode Episodes { get; set; } = default!;

    public DateTime BornDate { get; set; }
}

public class ActorConfiguration : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        builder.Property(guest => guest.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(guest => guest.Nationality)
            .IsRequired();

        builder.HasOne(guest => guest.Picture).WithOne()
            .HasForeignKey<Guest>(guest => guest.PictureId)
            .IsRequired();

        builder.HasOne(guest => guest.Episodes)
            .WithMany(episode => episode.Guests)
            .HasForeignKey(guest => guest.EpisodesId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}