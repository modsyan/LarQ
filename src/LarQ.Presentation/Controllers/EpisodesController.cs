using Microsoft.AspNetCore.Mvc;

namespace LarQ.Controllers;

[Route("/[controller]/")]
public class EpisodesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}