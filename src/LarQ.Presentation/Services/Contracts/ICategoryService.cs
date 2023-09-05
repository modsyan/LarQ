using LarQ.Core.Entities;
using LarQ.Services.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LarQ.Services.Contracts;

public interface ICategoryService
{
    public Task<Category> Get(Guid categoryId);
    public Task<IEnumerable<Category>> GetAll();
    public Task<IEnumerable<SelectListItem>> GetSelectedItems();
    public Task<Category> Create(Category category);
    public Task<Category> Update(Category category);
    public Task Remove(Guid categoryId);
}