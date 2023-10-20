using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using LarQ.DataAccess.Contracts;
using LarQ.DataAccess.Data;
using LarQ.DataAccess.Enums;


namespace LarQ.DataAccess.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly ApplicationDbContext _dbContext;

    public BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public T? Get(Guid id, IList<string>? includes = null)
    {
        return _dbContext.Find<T>(id);
    }

    public IEnumerable<T> Get(IList<string>? includes = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        includes ??= new List<string>();
        query = includes.Aggregate(query, (currentQueryValue, include) =>
            currentQueryValue.Include(include));

        return query.ToList();
    }

    public async Task<T?> GetAsync(Guid id, IList<string>? includes = null)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAsync(
        CancellationToken cancellationToken,
        IList<string>? includes = null,
        int? take = 5,
        int? skip = 0,
        Expression<Func<T, object>>? orderBy = null,
        string orderByDirection = OrderBy.Ascending
    )
    {
        IQueryable<T> query = _dbContext.Set<T>();
        includes ??= new List<string>();

        query = includes.Aggregate(query, (currentQueryValue, include)
            => currentQueryValue.Include(include));

        if (take.HasValue)
            query = query.Take((int)take);

        if (skip.HasValue && take.HasValue)
            query = query.Skip((int)(skip * take));

        if (orderBy != null)
            query = orderByDirection == OrderBy.Ascending
                ? query.OrderBy(orderBy)
                : query.OrderByDescending(orderBy);

        return await query.ToListAsync(cancellationToken);
    }

    public T? FindFirst(Expression<Func<T?, bool>> criteria, IList<string>? includes = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        includes ??= new List<string>();
        query = includes.Aggregate(query, (currentQueryValue, include) =>
            currentQueryValue.Include(include));

        return query.FirstOrDefault(criteria);
    }


    public T FindSingle(Expression<Func<T?, bool>> criteria, IList<string>? includes = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        includes ??= new List<string>();
        query = includes.Aggregate(query, (currentQueryValue, include) =>
            currentQueryValue.Include(include));

        var result = query.SingleOrDefault(criteria);

        if (result == null)
        {
            throw new ArgumentException("Entity with that criteria not found");
        }

        return result;
    }

    public async Task<T> FindSingleAsync(Expression<Func<T, bool>> criteria, CancellationToken cancellationToken,
        IList<string>? includes = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        includes ??= new List<string>();
        query = includes.Aggregate(query, (currentQueryValue, include) =>
            currentQueryValue.Include(include));

        var result = await query.SingleOrDefaultAsync(criteria, cancellationToken);

        if (result == null)
        {
            throw new ArgumentException("Entity with that criteria not found");
        }

        return result;
    }

    public async Task<T?> FindFirstAsync(Expression<Func<T?, bool>> criteria, CancellationToken cancellationToken,
        IList<string>? includes = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        includes ??= new List<string>();
        query = includes.Aggregate(query, (currentQueryValue, include) =>
            currentQueryValue.Include(include));

        var result = await query.SingleOrDefaultAsync(criteria, cancellationToken);

        return result;
    }

    public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, IList<string>? includes = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        includes ??= new List<string>();
        query = includes.Aggregate(query, (current, include) => current.Include(include));

        return query.Where(criteria).ToList();
    }

    public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take, int? skip)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take, int? skip,
        Expression<Func<T, object>>? orderBy,
        string orderByDirection = OrderBy.Ascending)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria,
        CancellationToken cancellationToken, IList<string>? includes = null)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        includes ??= new List<string>();
        query = includes.Aggregate(query, (currentQuery, include)
            => currentQuery.Include(include));

        return await query.Where(criteria).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria,
        CancellationToken cancellationToken, int? take, int? skip)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria,
        CancellationToken cancellationToken, int? take, int? skip,
        Expression<Func<T, object>>? orderBy,
        string orderByDirection = OrderBy.Ascending)
    {
        throw new NotImplementedException();
    }

    public T Create(T entity)
    {
        throw new NotImplementedException();
    }

    public void CreateRange(IEnumerable<T> entities)
    {
        _dbContext.AddRange(entities);
    }

    public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken)
    {
        var entityEntry = await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
        return entityEntry.Entity;
    }

    public async void CreateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(entities, cancellationToken);
    }

    public T Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        return entity;
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        _dbContext.Set<T>().UpdateRange(entities);
    }

    public void UpdateRange(Expression<Func<T, bool>> criteria)
    {
        // _dbContext.Set<T>().UpdateRange(entities);
        throw new NotImplementedException();
    }

    public bool Delete(Guid id)
    {
        var entity = _dbContext.Find<T>(id);
        if (entity is null) return false;
        _dbContext.Remove<T>(entity);
        return true;
    }

    public void Delete(T entity)

    {
        _dbContext.Set<T>().Remove(entity);
    }

    public bool Delete(Expression<Func<T, bool>> criteria)
    {
        throw new NotImplementedException();
    }


    public void DeleteRange(IEnumerable<Guid> ids)
    {
        var entityToDelete = new List<T>();

        if (entityToDelete == null)
            throw new ArgumentException("No Entity is Found with this ids to delete");

        entityToDelete
            .AddRange(ids.Select(id => _dbContext.Set<T>().Find(id))
                .Where(entity => entity != null)!);

        _dbContext.Set<T>().RemoveRange(entityToDelete);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        _dbContext.Set<T>().RemoveRange(entities);
    }

    public void DeleteRange(Expression<Func<T, bool>> criteria)
    {
        throw new NotImplementedException();
    }

    public T Attach(T entity)
    {
        // var attachedEntityEntry = _dbContext.Set<T>().Attach(entity);
        // var attached = attachedEntityEntry.Properties.Select(p=>p.IsModified = true);
        // return ;
        throw new NotImplementedException();
    }

    public IEnumerable<T> AttachRange(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public int Count()
    {
        return _dbContext.Set<T>().Count();
    }

    public int Count(Expression<Func<T, bool>> criteria)
    {
        return _dbContext.Set<T>().Where(criteria).Count();
    }

    public async Task<int> CountAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Set<T>().CountAsync(cancellationToken);
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> criteria, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<T>().Where(criteria).CountAsync(cancellationToken);
    }
}