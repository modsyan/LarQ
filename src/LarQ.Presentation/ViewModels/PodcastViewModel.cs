using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LarQ.ViewModels;

public class CreateUpdatePodcastViewModel
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public IFormFile Cover { get; set; } = default!;

    [DisplayName("Category")] public Guid CategoryId { get; set; } = default!;

    public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

    public IEnumerable<SelectListItem> Guests { get; set; } = Enumerable.Empty<SelectListItem>();

    [DisplayName("Guests")] public List<string> SelectedGuests { get; set; } = new ();
}