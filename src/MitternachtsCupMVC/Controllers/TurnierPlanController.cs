using Microsoft.AspNetCore.Mvc;

namespace MitternachtsCupMVC.Controllers;

public class TurnierPlanController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}