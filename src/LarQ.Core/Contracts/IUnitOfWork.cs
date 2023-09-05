using LarQ.Core.Entities;
using LarQ.DataAccess.Contracts;

namespace LarQ.Core.Contracts;

public interface IUnitOfWork : IDisposable
{
    public IBaseRepository<Podcast> Movies { get; }
    public IBaseRepository<Category> Categories { get; }
    public IBaseRepository<Guest> Actors { get; }
    public IBaseRepository<UploadedFile> Files { get; set; }

    public int Complete();
    public Task<int> CompleteAsync();
}