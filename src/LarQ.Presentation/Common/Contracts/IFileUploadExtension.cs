using LarQ.Core.Entities;

namespace LarQ.Common.Contracts;

public interface IFileUploadExtension
{
    public Task<UploadedFile> UploadFormFile(IFormFile file);
}