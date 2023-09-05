using LarQ.Core.Contracts;
using LarQ.Services.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LarQ.Services;

public class GuestService : IGuestService
{
    private readonly IUnitOfWork _unitOfWork;

    public GuestService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<SelectListItem>> GetSelectListItems()
    {
        var actors = await _unitOfWork.Actors.GetAsync();
        return actors
            .Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() })
            .OrderBy(a => a.Text)
            .ToList();
    }
}