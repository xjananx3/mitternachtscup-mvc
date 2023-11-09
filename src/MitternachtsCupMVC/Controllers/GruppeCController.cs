using Microsoft.AspNetCore.Mvc;
using MitternachtsCupMVC.Interfaces;

namespace MitternachtsCupMVC.Controllers;

public class GruppeCController : Controller
{
    private readonly ITeamRepository _teamRepository;

    public GruppeCController(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }
    public async Task<IActionResult> Index()
    {
        var teams = await _teamRepository.GetAll();

        var gruppeCTeams = teams
            .Where(t => t.Name == "Larios 2"
                        || t.Name == "Schluchhalder"
                        || t.Name == "Bohnenklopferinas"
                        || t.Name == "Schmetterball"
                        || t.Name == "Musikverein Sasbachried"
                        || t.Name == "Gruschtle"
                        || t.Name == "SoulEater").ToList();
        
        return View(gruppeCTeams);
    }
}