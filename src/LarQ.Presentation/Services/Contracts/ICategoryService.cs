using LarQ.Core.Entities;
using LarQ.Services.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LarQ.Services.Contracts;

public interface ICategoryService
{
    public Task<Category> Get(Guid categoryId, CancellationToken cancellationToken);
    public Task<IEnumerable<Category>> GetAll(CancellationToken cancellationToken);
    public Task<IEnumerable<SelectListItem>> GetSelectedItems(CancellationToken cancellationToken);
    public Task<Category> Create(Category category, CancellationToken cancellationToken);
    public Task<Category> Update(Category category);
    public Task Remove(Guid categoryId);
}