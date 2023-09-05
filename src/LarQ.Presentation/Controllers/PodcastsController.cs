using LarQ.Services;
using LarQ.Services.Contracts;
using LarQ.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Abstractions;

namespace LarQ.Controllers;

public class PodcastsController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IGuestService _guestService;

    public PodcastsController(ICategoryService categoryService, IGuestService guestService)
    {
        _categoryService = categoryService;
        _guestService = guestService;
    }

    public IActionResult Index()
    {
        return View();
    }


    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var viewModel = new CreateUpdatePodcastViewModel
        {
            Categories = await _categoryService.GetSelectedItems(),
            Guests = await _guestService.GetSelectListItems(),
        };
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CreateUpdatePodcastViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Save Movie
        // Save Cover

        return RedirectToAction(nameof(Index));
    }
}