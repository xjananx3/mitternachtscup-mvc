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
        var teams = await _teamRepository.GetAll();

        var spieleListe = new List<SpielViewModel>();
        string teamAName = string.Empty;
        string teamBName = string.Empty;

        foreach (var spiel in spiele)
        {
            foreach (var team in teams)
            {
                if (spiel.TeamAId == team.Id)
                {
                    teamAName = team.Name;
                }

                if (spiel.TeamBId == team.Id)
                {
                    teamBName = team.Name;
                }
                
            }
            var spieleViewModel = new SpielViewModel
            {
                Id = spiel.Id,
                Name = spiel.Name,
                Platte = spiel.Platte,
                StartZeit = spiel.StartZeit,
                SpielDauer = spiel.SpielDauer,
                TeamAId = spiel.TeamAId,
                TeamAName = teamAName,
                TeamBName = teamBName,
                TeamBId = spiel.TeamBId
            };
            spieleListe.Add(spieleViewModel);
        }
        
        return View(spieleListe);
    }

    public IActionResult Create(int teamAId, int teamBId)
    {
        var createSpielViewModel = new CreateSpielViewModel
        {
            TeamAId = teamAId,
            TeamBId = teamBId
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
    
    public async Task<IActionResult> Delete(int id)
    {
        var spielDetails = await _spielRepository.GetByIdAsync(id);
        if (spielDetails == null) return View("Error");
        return View(spielDetails);
    }
    
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteSpiel(int id)
    {
        var spielDetails = await _spielRepository.GetByIdAsync(id);
        if (spielDetails == null) return View("Error");

        _spielRepository.Delete(spielDetails);
        return RedirectToAction("Index");
    }
}