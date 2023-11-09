using Microsoft.AspNetCore.Mvc;

namespace MitternachtsCupMVC.Controllers;

public class GruppeCController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}