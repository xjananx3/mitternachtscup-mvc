using Microsoft.AspNetCore.Mvc;

namespace MitternachtsCupMVC.Controllers;

public class GruppeDController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}