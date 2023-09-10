using System.ComponentModel;
using ChustaSoft.Services.StaticData.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LarQ.ViewModels;

public class EpisodeViewModel
{
    
    [DisplayName("Guests")] public List<string> SelectedGuests { get; set; } = new ();
    public IEnumerable<SelectListItem> Nationalities { get; set; } = Enumerable.Empty<SelectListItem>();
    [DisplayName("Nationalities")] public List<Country> SelectedNationalities { get; set; } = new ();
}