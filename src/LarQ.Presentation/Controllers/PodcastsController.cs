using System.Security.Claims;
using ChustaSoft.Services.StaticData.Models;
using ChustaSoft.Services.StaticData.Services;
using LarQ.Services;
using LarQ.Services.Contracts;
using LarQ.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.IdentityModel.Abstractions;
using Newtonsoft.Json;

namespace LarQ.Controllers;

public class PodcastsController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IGuestService _guestService;
    private readonly IPodcastService _podcastService;

    public PodcastsController(ICategoryService categoryService, IGuestService guestService,
        ICountryService countryService, IPodcastService podcastService)
    {
        _categoryService = categoryService;
        _guestService = guestService;
        _podcastService = podcastService;
    }

    public IActionResult Index(int page = 0, int size = 20)
    {
        var podcasts = _podcastService.GetAll(page, size);
        
        return View();
    }


    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var viewModel = new CreateOrUpdatePodcastViewModel
        {
            Categories = await _categoryService.GetSelectedItems(),
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateOrUpdatePodcastViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await _podcastService.Create(model);

        return RedirectToAction(nameof(Index));
    }
}