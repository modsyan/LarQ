using Microsoft.AspNetCore.Mvc;

namespace LarQ.Controllers;

public class EpisodesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}