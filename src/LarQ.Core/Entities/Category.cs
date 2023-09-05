using LarQ.Core.Common;
using LarQ.Core.Enums;
using LarQ.DataAccess.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LarQ.Core.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = null!;

    public Guid IconId { get; set; }

    public UploadedFile Icon { get; set; } = null!;

    public virtual ICollection<Podcast> Podcasts { get; set; } = new List<Podcast>();
}

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(category => category.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasOne(category => category.Icon)
            .WithMany()
            .HasForeignKey(category => category.IconId)
            .OnDelete(DeleteBehavior.ClientCascade)
            .IsRequired();

        builder.HasMany(podcast => podcast.Podcasts)
            .WithOne(podcast => podcast.Category)
            .HasForeignKey(podcast => podcast.CategoryId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.Property(category => category.CreateAt)
            .ValueGeneratedOnAdd();

        builder.Property(category => category.UpdatedAt)
            .ValueGeneratedOnUpdate();
    }
}