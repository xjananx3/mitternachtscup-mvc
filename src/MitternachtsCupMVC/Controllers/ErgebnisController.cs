using Microsoft.AspNetCore.Mvc;
using MitternachtsCupMVC.Interfaces;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC.Controllers;

public class ErgebnisController : Controller
{
    private readonly IErgebnisRepository _ergebnisRepository;
    private readonly ISpielRepository _spielRepository;
    private readonly ITeamRepository _teamRepository;

    public ErgebnisController(IErgebnisRepository ergebnisRepository, ISpielRepository spielRepository, ITeamRepository teamRepository)
    {
        _ergebnisRepository = ergebnisRepository;
        _spielRepository = spielRepository;
        _teamRepository = teamRepository;
    }
    public async Task<IActionResult> Index()
    {
        var ergebnisse = await _ergebnisRepository.GetAll();
        var spiele = await _spielRepository.GetAll();
        var teams = await _teamRepository.GetAll();

        var ergebnisListe = new List<ErgebnisViewModel>();
        string spielName = string.Empty;
        string gewinnerTeamName = string.Empty;
        string teamAName = string.Empty;
        string teamBName = string.Empty;

        foreach (var ergebnis in ergebnisse)
        {
            foreach (var spiel in spiele)
            {
                if (ergebnis.SpielId == spiel.Id)
                {
                    spielName = spiel.Name;
                    
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
                    if (ergebnis.PunkteTeamA > ergebnis.PunkteTeamB)
                    {
                        gewinnerTeamName = spiel.TeamA.Name;
                    }
                    else
                    {
                        gewinnerTeamName = spiel.TeamB.Name;
                    }
                }
            }
            var ergebnisVm = new ErgebnisViewModel()
            {
                Id = ergebnis.Id,
                SpielName = spielName,
                SpielId = ergebnis.SpielId,
                TeamAName = teamAName,
                PunkteTeamA = ergebnis.PunkteTeamA,
                TeamBName = teamBName,
                PunkteTeamB = ergebnis.PunkteTeamB,
                GewinnerTeamId = ergebnis.TeamId,
                GewinnerTeamName = gewinnerTeamName
            };
            ergebnisListe.Add(ergebnisVm);
        }
        
        return View(ergebnisListe);
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
            Spiel = ergebnisVm.Spiel,
            TeamId = ergebnisVm.TeamId,
            GewinnerTeam = ergebnisVm.GewinnerTeam,
        };

        _ergebnisRepository.Add(ergebnis);
        return View(ergebnisVm);
    }
}