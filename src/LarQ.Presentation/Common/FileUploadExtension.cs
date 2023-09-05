using LarQ.Core.Entities;

namespace LarQ.Common;

public static class FileUploadExtension
{
    public static async Task<UploadedFile?> UploadFormFile(IWebHostEnvironment webHostEnvironment, IFormFile file)
    {
        if (file.Length == 0) return null;

        var wwwRootPath = webHostEnvironment.WebRootPath;
        var uploadsFolder = Path.Combine(wwwRootPath, "uploads");

        var fileId = Guid.NewGuid();
        var genFileName = $"{fileId}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(uploadsFolder, genFileName);

        var uploadedFile = new UploadedFile
        {
            Id = fileId,
            FileName = genFileName,
            OriginalFileName = file.FileName,
            FilePath = filePath,
            ContentType = file.ContentType,
        };

        await using var stream = File.Create(filePath);
        await file.CopyToAsync(stream);
        await stream.DisposeAsync();

        return uploadedFile;
    }
}