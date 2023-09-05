using Microsoft.AspNetCore.Mvc;

namespace LarQ.Controllers;

public class CategoriesController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

}