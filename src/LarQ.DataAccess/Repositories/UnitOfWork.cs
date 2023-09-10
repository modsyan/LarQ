using LarQ.Core.Contracts;
using LarQ.Core.Entities;
using LarQ.DataAccess.Contracts;
using LarQ.DataAccess.Data;

namespace LarQ.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext, IBaseRepository<Podcast> podcasts, IBaseRepository<Guest> guests,
        IBaseRepository<Category> categories, IBaseRepository<UploadedFile> files)
    {
        _dbContext = dbContext;
        Categories = categories;
        Files = files;
        Podcasts = podcasts;
        Guests = guests;
    }

    public IBaseRepository<Podcast> Podcasts { get; }
    public IBaseRepository<Category> Categories { get; }
    public IBaseRepository<Guest> Guests { get; }
    public IBaseRepository<UploadedFile> Files { get; set; }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public int Complete()
    {
        return _dbContext.SaveChanges();
    }

    public async Task<int> CompleteAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}