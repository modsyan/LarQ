using Microsoft.AspNetCore.Mvc;

namespace LarQ.Controllers;

public class StudioController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}