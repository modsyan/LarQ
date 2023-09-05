using LarQ.Core.Entities;
using LarQ.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace LarQ.Core.Seeds;

public static class CategorySeeder
{
    public static void AddCategorySeed(this ModelBuilder builder)
    {
        
        var picture = new UploadedFile
        {
            Id = Guid.NewGuid(),
            FileName = "GuestImage",
            OriginalFileName = "23511317.jpg",
            ContentType = "jpg",
            FilePath = "/home/modsyan/projects/" //TODO:Until Handling Configurations
        };

        builder.Entity<UploadedFile>().HasData(picture);
        
        builder.Entity<Category>().HasData(new List<Category>
        {
            new Category {Id = Guid.NewGuid(),Name = "Action", IconId = picture.Id},
            new Category {Id = Guid.NewGuid(),Name = "Adventure", IconId = picture.Id },
            new Category {Id = Guid.NewGuid(),Name = "Animation", IconId = picture.Id },
            new Category {Id = Guid.NewGuid(),Name = "Comedy", IconId = picture.Id },
            new Category {Id = Guid.NewGuid(),Name = "Crime", IconId = picture.Id },
            new Category {Id = Guid.NewGuid(),Name = "Documentary", IconId = picture.Id },
            new Category {Id = Guid.NewGuid(),Name = "Drama", IconId = picture.Id },
            new Category {Id = Guid.NewGuid(),Name = "Family", IconId = picture.Id },
            new Category {Id = Guid.NewGuid(),Name = "Fantasy", IconId = picture.Id },
            new Category {Id = Guid.NewGuid(),Name = "History", IconId = picture.Id },
            new Category {Id = Guid.NewGuid(),Name = "Horror", IconId = picture.Id },
            new Category {Id = Guid.NewGuid(),Name = "Music", IconId = picture.Id },
            new Category {Id = Guid.NewGuid(),Name = "Mystery", IconId = picture.Id },
            new Category {Id = Guid.NewGuid(),Name = "Romance", IconId = picture.Id },
            new Category {Id = Guid.NewGuid(),Name = "ScienceFiction", IconId = picture.Id },
            new Category {Id = Guid.NewGuid(),Name = "Thriller", IconId = picture.Id },
            new Category {Id = Guid.NewGuid(),Name = "War", IconId = picture.Id },
            new Category {Id = Guid.NewGuid(),Name = "Western", IconId = picture.Id },
        });
    }
}