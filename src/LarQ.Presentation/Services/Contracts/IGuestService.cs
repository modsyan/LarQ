using Microsoft.AspNetCore.Mvc.Rendering;

namespace LarQ.Services.Contracts;

public interface IGuestService
{
    public Task<IEnumerable<SelectListItem>> GetSelectListItems(CancellationToken cancellationToken);
}