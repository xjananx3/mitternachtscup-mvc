using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MitternachtsCupMVC.Data;

namespace MitternachtsCupMVC.Controllers;

public class TeamController : Controller
{
    private readonly ApplicationDbContext _context;

    public TeamController(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var teams = await _context.Teams.ToListAsync();
        return View(teams);
    }
}