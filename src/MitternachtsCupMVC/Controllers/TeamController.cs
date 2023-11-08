using Microsoft.AspNetCore.Mvc;

namespace MitternachtsCupMVC.Controllers;

public class TeamController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}