using Microsoft.AspNetCore.Mvc;
using MitternachtsCupMVC.Interfaces;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC.Controllers;

public class ErgebnisController : Controller
{
    private readonly IErgebnisRepository _ergebnisRepository;

    public ErgebnisController(IErgebnisRepository ergebnisRepository)
    {
        _ergebnisRepository = ergebnisRepository;
    }
    public async Task<IActionResult> Index()
    {
        var ergebnisse = await _ergebnisRepository.GetAll();
        
        return View(ergebnisse);
    }

    public IActionResult CreateAusSpiel(int spielId)
    {
        var createErgebnisViewModel = new CreateErgebnisViewModel()
        {
            SpielId = spielId
        };

        return View(createErgebnisViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateErgebnisViewModel ergebnisVm)
    {
        var ergebnis = new Ergebnis()
        {
            PunkteTeamA = ergebnisVm.PunkteTeamA,
            PunkteTeamB = ergebnisVm.PunkteTeamB,
            SpielId = ergebnisVm.SpielId,
            TeamId = ergebnisVm.TeamId,
            GewinnerTeam = ergebnisVm.GewinnerTeam,
        };

        _ergebnisRepository.Add(ergebnis);
        return View(ergebnisVm);
    }
}