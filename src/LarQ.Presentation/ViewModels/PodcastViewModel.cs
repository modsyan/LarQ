using System.ComponentModel;
using System.Runtime.CompilerServices;
using ChustaSoft.Services.StaticData.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LarQ.ViewModels;

public class CreateOrUpdatePodcastViewModel
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public IFormFile Cover { get; set; } = default!;

    [DisplayName("Category")] public Guid CategoryId { get; set; } = default!;

    public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
}

public class GetPodcastViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid HostId { get; set; }

    public string HostName { get; set; } = default!;

    public Guid CoverId { get; set; }

    public IFormFile Cover { get; set; } = default!;

    public Guid CategoryId { get; set; }

    public string CategoryName { get; set; } = default!;

    public int Episodes { get; set; }

    public int Subscribes { get; set; }
}

public class GetPodcastDetailViewModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public HostViewModel Host { get; set; } = default!;

    public Guid CoverId { get; set; }

    public IFormFile Cover { get; set; } = default!;

    public Guid CategoryId { get; set; }

    public string CategoryName { get; set; } = default!;

    public IEnumerable<EpisodeViewModel> Episodes { get; set; } = new List<EpisodeViewModel>();

    public int Subscribes { get; set; }
}