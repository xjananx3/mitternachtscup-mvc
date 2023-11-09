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

    public IActionResult Create()
    {
        var createSpielViewModel = new CreateSpielViewModel
        {

        };
        return View(createSpielViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSpielViewModel spielVm)
    {
        
        
            var spiel = new Spiel
            {
                Name = spielVm.Name,
                Platte = spielVm.Platte,
                StartZeit = spielVm.StartZeit,
                SpielDauer = spielVm.SpielDauer,
                TeamAId = spielVm.TeamAId,
                TeamA = spielVm.TeamA,
                TeamBId = spielVm.TeamBId,
                TeamB = spielVm.TeamB
            };
            _spielRepository.Add(spiel);
            return RedirectToAction("Index");

    
    }
}