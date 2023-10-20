using LarQ.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LarQ.Controllers;

public class StudioController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    
    [HttpGet]
    public IActionResult CreateHost()
    {
        return View("Index");

    }
    
    [HttpPost]
    public IActionResult CreateHost(CreateHostDto dto)
    {
        return View("Index");
    }
}