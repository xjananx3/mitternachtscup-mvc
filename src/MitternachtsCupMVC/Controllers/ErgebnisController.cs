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

    public IActionResult CreateAusTurnierplan(int spielId, int punkteTeamA, int punkteTeamB, int gewinnerTeamId)
    {
        var createErgebnisViewMode = new CreateErgebnisViewModel()
        {
            SpielId = spielId,
            PunkteTeamA = punkteTeamA,
            PunkteTeamB = punkteTeamB,
            TeamId = gewinnerTeamId
        };

        return View(createErgebnisViewMode);
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
        return RedirectToAction("Index", "Turnierplan");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var ergebnis = await _ergebnisRepository.GetByIdAsync(id);
        if (ergebnis == null) return View("Error");

        var ergebnisVm = new EditErgebnisViewModel()
        {
            PunkteTeamA = ergebnis.PunkteTeamA,
            PunkteTeamB = ergebnis.PunkteTeamB,
            SpielId = ergebnis.SpielId,
            Spiel = ergebnis.Spiel,
            TeamId = ergebnis.TeamId,
            GewinnerTeam = ergebnis.GewinnerTeam
        };
        return View(ergebnisVm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, EditErgebnisViewModel ergebnisVm)
    {
        var ergebnisDetails = await _ergebnisRepository.GetByIdAsyncNoTracking(id);
        if (ergebnisDetails == null) return View("Error");

        var ergebnis = new Ergebnis
        {
            Id = id,
            PunkteTeamA = ergebnisVm.PunkteTeamA,
            PunkteTeamB = ergebnisVm.PunkteTeamB,
            SpielId = ergebnisVm.SpielId,
            TeamId = ergebnisVm.TeamId
        };
        _ergebnisRepository.Update(ergebnis);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var ergebnisDetails = await _ergebnisRepository.GetByIdAsync(id);
        if (ergebnisDetails == null) return View("Error");
        return View(ergebnisDetails);
    }
    
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteErgebnis(int id)
    {
        var ergebnis = await _ergebnisRepository.GetByIdAsync(id);
        if (ergebnis == null) return View("Error");

        _ergebnisRepository.Delete(ergebnis);
        return RedirectToAction("Index");
    }
}