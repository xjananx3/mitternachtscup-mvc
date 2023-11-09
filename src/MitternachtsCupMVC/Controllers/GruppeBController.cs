using Microsoft.AspNetCore.Mvc;
using MitternachtsCupMVC.Interfaces;

namespace MitternachtsCupMVC.Controllers;

public class GruppeBController : Controller
{
    private readonly ITeamRepository _teamRepository;

    public GruppeBController(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var teams = await _teamRepository.GetAll();

        var gruppeBteams = teams
            .Where(t => t.Name == "Bohnenkloper 2"
                        || t.Name == "RSkaliert"
                        || t.Name == "Team Havana"
                        || t.Name == "Dummy Team 1"
                        || t.Name == "Rieder Piraten 1"
                        || t.Name == "Spritzer"
                        || t.Name == "Team Dobex"
                        || t.Name == "Space Team 1").ToList();
        
        return View(gruppeBteams);
    }
}