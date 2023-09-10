using LarQ.Common.Contracts;
using LarQ.Configuration;
using LarQ.Core.Entities;
using LarQ.Settings;
using Microsoft.Extensions.Options;

namespace LarQ.Common;

public class FileUploadExtension : IFileUploadExtension
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IOptions<FileOptionModel> _fileOptions;

    public FileUploadExtension(IWebHostEnvironment webHostEnvironment, IOptions<FileOptionModel> fileOptions)
    {
        _webHostEnvironment = webHostEnvironment;
        _fileOptions = fileOptions;
    }

    public async Task<UploadedFile> UploadFormFile(IFormFile file)
    {
        if (file.Length == 0) throw new Exception("cover is empty");

        var uploadsFolder = $"{_webHostEnvironment.WebRootPath}{_fileOptions.Value.WwwRootImagePath}";

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

        // await using var stream = File.Create(filePath);
        await using var stream = File.Create(filePath);
        await file.CopyToAsync(stream);
        // await stream.DisposeAsync();

        return uploadedFile;
    }

    public async Task<byte[]> DownloadFormFile(UploadedFile file)
    {
        // await using var stream = File.Create(filePath);
        // await file.CopyToAsync(stream);
        // await stream.DisposeAsync();
        //
        // return uploadedFile;

        // var memoryStream = new MemoryStream();
        // var fileStream =  await File.ReadAllBytesAsync(file.FilePath);
        // fileStream.CopyTo(memoryStream);
        return await File.ReadAllBytesAsync(file.FilePath);
    }
}