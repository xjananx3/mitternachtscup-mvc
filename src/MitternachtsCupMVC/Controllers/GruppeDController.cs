using Microsoft.AspNetCore.Mvc;
using MitternachtsCupMVC.Interfaces;

namespace MitternachtsCupMVC.Controllers;

public class GruppeDController : Controller
{
    private readonly ITeamRepository _teamRepository;

    public GruppeDController(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }
    public async Task<IActionResult> Index()
    {
        var teams = await _teamRepository.GetAll();

        var gruppeDteams = teams
            .Where(t => t.Name == "Rieder Piraten 2"
                        || t.Name == "Maflotho"
                        || t.Name == "The Old Schmetterhänds"
                        || t.Name == "Dummy Team 3"
                        || t.Name == "OlympAllstars"
                        || t.Name == "Kräuterhexen"
                        || t.Name == "Geschwister Bauer"
                        || t.Name == "Space Team 2").ToList();
        
        return View(gruppeDteams);
    }
}