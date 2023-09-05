using AutoMapper;
using LarQ.Core.Contracts;
using LarQ.Core.Entities;
using LarQ.DataAccess.Repositories;
using LarQ.Services.Base;
using LarQ.Services.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LarQ.Services;

public class CategoryService : BaseService<ICategoryService>, ICategoryService
{
    public CategoryService(IMapper mapper, ILogger<ICategoryService> logger, IUnitOfWork unitOfWork)
        : base(unitOfWork, mapper, logger)
    {
    }

    public async Task<Category> Get(Guid categoryId)
    {
        return await UnitOfWork.Categories.FindSingleAsync(c => c.Id == categoryId);
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await UnitOfWork.Categories.GetAsync();
    }

    public async Task<IEnumerable<SelectListItem>> GetSelectedItems()
    {
        var categories = await UnitOfWork.Categories.GetAsync();
        return categories
            .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
            .OrderBy(c => c.Text)
            .ToList();
    }

    public async Task<Category> Create(Category category)
    {
        var newCategory = await UnitOfWork.Categories.CreateAsync(category);
        await UnitOfWork.CompleteAsync();
        return newCategory;
    }

    public async Task<Category> Update(Category category)
    {
        var newCategory = UnitOfWork.Categories.Update(category);
        await UnitOfWork.CompleteAsync();
        return newCategory;
    }

    public async Task Remove(Guid categoryId)
    {
        UnitOfWork.Categories.Delete(categoryId);
        await UnitOfWork.CompleteAsync();
    }
}