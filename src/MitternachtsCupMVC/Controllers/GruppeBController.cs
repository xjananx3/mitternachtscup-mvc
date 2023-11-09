using Microsoft.AspNetCore.Mvc;

namespace MitternachtsCupMVC.Controllers;

public class GruppeBController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}