using LarQ.Core.Contracts;
using LarQ.Core.Entities;
using LarQ.DataAccess.Contracts;
using LarQ.DataAccess.Data;

namespace LarQ.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext, IBaseRepository<Podcast> movies, IBaseRepository<Category> categories, IBaseRepository<Guest> actors, IBaseRepository<UploadedFile> files)
    {
        _dbContext = dbContext;
        Movies = movies;
        Categories = categories;
        Actors = actors;
        Files = files;
    }

    public IBaseRepository<Podcast> Movies { get; }
    public IBaseRepository<Category> Categories { get; }
    public IBaseRepository<Guest> Actors { get; }
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