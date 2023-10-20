using Microsoft.AspNetCore.Mvc.Rendering;

namespace LarQ.ViewModels;

public class HostViewModel
{
    public required string Name { get; set; }
}

public class CreateHostDto
{   
    
    public IEnumerable<SelectListItem> Owners { get; set; } = Enumerable.Empty<SelectListItem>();
}