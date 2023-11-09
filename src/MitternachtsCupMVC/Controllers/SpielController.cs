using Microsoft.AspNetCore.Mvc;
using MitternachtsCupMVC.Data;
using MitternachtsCupMVC.Interfaces;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC.Controllers;

public class SpielController : Controller
{
    private readonly ISpielRepository _spielRepository;
    private readonly ITeamRepository _teamRepository;

    public SpielController(ISpielRepository spielRepository, ITeamRepository teamRepository)
    {
        _spielRepository = spielRepository;
        _teamRepository = teamRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var spiele = await _spielRepository.GetAll();
        return View(spiele);
    }

    public async Task<IActionResult> Create(int teamAId, int teamBId)
    {
        var teamA = await _teamRepository.GetByIdAsync(teamAId);
        var teamB = await _teamRepository.GetByIdAsync(teamBId);

        var createSpielViewModel = new CreateSpielViewModel
        {
            TeamA = teamA,
            TeamB = teamB
        };
        
        return View(createSpielViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSpielViewModel spielVm)
    {
        
        if (ModelState.IsValid)
        {
            var spiel = new Spiel
            {
                Name = spielVm.Name,
                Platte = spielVm.Platte,
                StartZeit = spielVm.StartZeit,
                SpielDauer = spielVm.SpielDauer,
                TeamA = spielVm.TeamA,
                TeamB = spielVm.TeamB
            };
            _spielRepository.Add(spiel);
            return RedirectToAction("Index");
        }

        return View(spielVm);
    }
}