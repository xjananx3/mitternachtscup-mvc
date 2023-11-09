using Microsoft.AspNetCore.Mvc;
using MitternachtsCupMVC.Interfaces;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC.Controllers;

public class GruppeAController : Controller
{
    private readonly ITeamRepository _teamRepository;

    public GruppeAController(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var teams = await _teamRepository.GetAll();

        var gruppeAteams = teams
            .Where(t => t.Name == "Bohnenkloper 1"
                        || t.Name == "Durschdlöscher"
                        || t.Name == "MaLongSom"
                        || t.Name == "Test 123"
                        || t.Name == "Larios 1"
                        || t.Name == "Moorknechte Sasbachried"
                        || t.Name == "Rheingoldstraße"
                        || t.Name == "Jungspritzer").ToList();
        
        return View(gruppeAteams);
    }
}