using System.Security.Claims;
using ChustaSoft.Services.StaticData.Models;
using ChustaSoft.Services.StaticData.Services;
using LarQ.Services;
using LarQ.Services.Contracts;
using LarQ.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

    public async Task<IActionResult> Index(CancellationToken cancellationToken, int page = 0, int size = 20)
    {
        var podcasts = await _podcastService.GetAll(cancellationToken, page, size);

        return View(podcasts);
    }


    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Create(CancellationToken cancellationToken)
    {
        var viewModel = new CreateOrUpdatePodcastViewModel
        {
            Categories = await _categoryService.GetSelectedItems(),
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateOrUpdatePodcastViewModel model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await _podcastService.Create(model, cancellationToken);

        return RedirectToAction(nameof(Index));
    }
}