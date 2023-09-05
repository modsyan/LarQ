using LarQ.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LarQ.Core.Seeds;

public static class GuestSeeder
{
    // Just For Development Purposes
    public static void AddGuestSeeder(this ModelBuilder modelBuilder)
    {
        var picture = new UploadedFile
        {
            Id = Guid.NewGuid(),
            FileName = "GuestImage",
            OriginalFileName = "23511317.jpg",
            ContentType = "jpg",
            FilePath = "/home/modsyan/projects/" //TODO:Until Handling Configurations
        };

        modelBuilder.Entity<UploadedFile>().HasData(picture);

        modelBuilder.Entity<Guest>().HasData(new List<Guest>
            {
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Omar Sharif",
                    BornDate = new DateTime(1932, 4, 10),
                    Nationality = "Egyptian"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Shah Rukh Khan",
                    BornDate = new DateTime(1965, 11, 2), Nationality = "Indian"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Meryl Streep",
                    BornDate = new DateTime(1949, 6, 22),
                    Nationality = "American"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Adel Emam",
                    BornDate = new DateTime(1940, 5, 17),
                    Nationality = "Egyptian"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Tom Hanks",
                    BornDate = new DateTime(1956, 7, 9),
                    Nationality = "American"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Aamir Khan",
                    BornDate = new DateTime(1965, 3, 14),
                    Nationality = "Indian"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Leonardo DiCaprio",
                    BornDate = new DateTime(1974, 11, 11), Nationality = "American"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Salman Khan",
                    BornDate = new DateTime(1965, 12, 27),
                    Nationality = "Indian"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Faten Hamama",
                    BornDate = new DateTime(1931, 5, 27),
                    Nationality = "Egyptian"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Penélope Cruz",
                    BornDate = new DateTime(1974, 4, 28), Nationality = "Spanish"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Ahmed Zaki",
                    BornDate = new DateTime(1949, 11, 18),
                    Nationality = "Egyptian"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Mahira Khan",
                    BornDate = new DateTime(1984, 12, 21),
                    Nationality = "Pakistani"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Amr Waked",
                    BornDate = new DateTime(1973, 4, 12),
                    Nationality = "Egyptian"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Haifa Wehbe",
                    BornDate = new DateTime(1976, 3, 10),
                    Nationality = "Lebanese"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Johnny Depp",
                    BornDate = new DateTime(1963, 6, 9),
                    Nationality = "American"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Amitabh Bachchan",
                    BornDate = new DateTime(1942, 10, 11), Nationality = "Indian"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Julia Roberts",
                    BornDate = new DateTime(1967, 10, 28), Nationality = "American"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Khaled Abol Naga",
                    BornDate = new DateTime(1966, 11, 2), Nationality = "Egyptian"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Robert De Niro",
                    BornDate = new DateTime(1943, 8, 17), Nationality = "American"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Nawal El Saadawi",
                    BornDate = new DateTime(1930, 10, 27), Nationality = "Egyptian"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Cate Blanchett",
                    BornDate = new DateTime(1969, 5, 14), Nationality = "Australian"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Morgan Freeman",
                    BornDate = new DateTime(1937, 6, 1), Nationality = "American"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Monica Bellucci",
                    BornDate = new DateTime(1964, 9, 30), Nationality = "Italian"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Keanu Reeves",
                    BornDate = new DateTime(1964, 9, 2),
                    Nationality = "Canadian"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Denzel Washington",
                    BornDate = new DateTime(1954, 12, 28), Nationality = "American"
                },
                new Guest
                {
                    Id = Guid.NewGuid(), PictureId = picture.Id, Name = "Nelly Karim",
                    BornDate = new DateTime(1974, 12, 18),
                    Nationality = "Egyptian"
                },
            }
        );
    }
}