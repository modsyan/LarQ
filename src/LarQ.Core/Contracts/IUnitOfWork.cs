using LarQ.Core.Entities;
using LarQ.DataAccess.Contracts;

namespace LarQ.Core.Contracts;

public interface IUnitOfWork : IDisposable
{
    public IBaseRepository<Podcast> Podcasts { get; }
    public IBaseRepository<Category> Categories { get; }
    public IBaseRepository<Guest> Guests { get; }
    public IBaseRepository<UploadedFile> Files { get; set; }

    public int Complete();
    public Task<int> CompleteAsync();
}