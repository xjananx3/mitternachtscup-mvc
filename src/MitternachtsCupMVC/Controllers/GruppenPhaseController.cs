using Microsoft.AspNetCore.Mvc;
using MitternachtsCupMVC.Interfaces;
using MitternachtsCupMVC.Repository;

namespace MitternachtsCupMVC.Controllers;

public class GruppenPhaseController : Controller
{
    private readonly IGruppenPhaseRepository _gruppenPhaseRepository;

    public GruppenPhaseController(IGruppenPhaseRepository gruppenPhaseRepository)
    {
        _gruppenPhaseRepository = gruppenPhaseRepository;
    }
    public async Task<IActionResult> Index()
    {
        var teamsA = await _gruppenPhaseRepository.GetGruppeATeams();
        var kommendeSpieleA = await _gruppenPhaseRepository.GetKommendeGruppeASpiele();
        var vergangeneSpieleA = await _gruppenPhaseRepository.GetVergangeneGruppeASpiele();
        
        var teamsB = await _gruppenPhaseRepository.GetGruppeBTeams();
        var kommendeSpieleB = await _gruppenPhaseRepository.GetKommendeGruppeBSpiele();
        var vergangeneSpieleB = await _gruppenPhaseRepository.GetVergangeneGruppeBSpiele();
        
        var teamsC = await _gruppenPhaseRepository.GetGruppeCTeams();
        var kommendeSpieleC = await _gruppenPhaseRepository.GetKommendeGruppeCSpiele();
        var vergangeneSpieleC = await _gruppenPhaseRepository.GetVergangeneGruppeCSpiele();
        
        var teamsD = await _gruppenPhaseRepository.GetGruppeDTeams();
        var kommendeSpieleD = await _gruppenPhaseRepository.GetKommendeGruppeDSpiele();
        var vergangeneSpieleD = await _gruppenPhaseRepository.GetVergangeneGruppeDSpiele();
        
        var teamsE = await _gruppenPhaseRepository.GetGruppeETeams();
        var kommendeSpieleE = await _gruppenPhaseRepository.GetKommendeGruppeESpiele();
        var vergangeneSpieleE = await _gruppenPhaseRepository.GetVergangeneGruppeESpiele();
        
        var teamsF = await _gruppenPhaseRepository.GetGruppeFTeams();
        var kommendeSpieleF = await _gruppenPhaseRepository.GetKommendeGruppeFSpiele();
        var vergangeneSpieleF = await _gruppenPhaseRepository.GetVergangeneGruppeFSpiele();
        
        var teamsG = await _gruppenPhaseRepository.GetGruppeGTeams();
        var kommendeSpieleG = await _gruppenPhaseRepository.GetKommendeGruppeGSpiele();
        var vergangeneSpieleG = await _gruppenPhaseRepository.GetVergangeneGruppeGSpiele();

        var gruppenAnzeigeVm = new GruppenPhaseViewModel()
        {
            GruppeATeams = teamsA,
            KommendeGruppeASpiele = kommendeSpieleA,
            VergangeneGruppeASpiele = vergangeneSpieleA,
            GruppeBTeams = teamsB,
            KommendeGruppeBSpiele = kommendeSpieleB,
            VergangeneGruppeBSpiele = vergangeneSpieleB,
            GruppeCTeams = teamsC,
            KommendeGruppeCSpiele = kommendeSpieleC,
            VergangeneGruppeCSpiele = vergangeneSpieleC,
            GruppeDTeams = teamsD,
            KommendeGruppeDSpiele = kommendeSpieleD,
            VergangeneGruppeDSpiele = vergangeneSpieleD,
            GruppeETeams = teamsE,
            KommendeGruppeESpiele = kommendeSpieleE,
            VergangeneGruppeESpiele = vergangeneSpieleE,
            GruppeFTeams = teamsF,
            KommendeGruppeFSpiele = kommendeSpieleF,
            VergangeneGruppeFSpiele = vergangeneSpieleF,
            GruppeGTeams = teamsG,
            KommendeGruppeGSpiele = kommendeSpieleG,
            VergangeneGruppeGSpiele = vergangeneSpieleG
        };
        
        return View(gruppenAnzeigeVm);
    }

    public async Task<IActionResult> GruppeA()
    {
        var teamsA = await _gruppenPhaseRepository.GetGruppeATeams();
        var kommendeSpieleA = await _gruppenPhaseRepository.GetKommendeGruppeASpiele();
        var vergangeneSpieleA = await _gruppenPhaseRepository.GetVergangeneGruppeASpiele();

        var gruppenAnzeigeVm = new GruppenPhaseViewModel
        {
            GruppeATeams = teamsA,
            KommendeGruppeASpiele = kommendeSpieleA,
            VergangeneGruppeASpiele = vergangeneSpieleA
        };

        return View(gruppenAnzeigeVm);
    }
    
    public async Task<IActionResult> GruppeB()
    {
        var teamsB = await _gruppenPhaseRepository.GetGruppeBTeams();
        var kommendeSpieleB = await _gruppenPhaseRepository.GetKommendeGruppeBSpiele();
        var vergangeneSpieleB = await _gruppenPhaseRepository.GetVergangeneGruppeBSpiele();

        var gruppenPhaseVm = new GruppenPhaseViewModel
        {
            GruppeBTeams = teamsB,
            KommendeGruppeBSpiele = kommendeSpieleB,
            VergangeneGruppeBSpiele = vergangeneSpieleB
        };
        return View(gruppenPhaseVm);
    }
    
    public async Task<IActionResult> GruppeC()
    {
        var teamsC = await _gruppenPhaseRepository.GetGruppeCTeams();
        var kommendeSpieleC = await _gruppenPhaseRepository.GetKommendeGruppeCSpiele();
        var vergangeneSpieleC = await _gruppenPhaseRepository.GetVergangeneGruppeCSpiele();

        var gruppenPhaseVm = new GruppenPhaseViewModel
        {
            GruppeCTeams = teamsC,
            KommendeGruppeCSpiele = kommendeSpieleC,
            VergangeneGruppeCSpiele = vergangeneSpieleC
        };
        return View(gruppenPhaseVm);
    }
    
    public async Task<IActionResult> GruppeD()
    {
        var teamsD = await _gruppenPhaseRepository.GetGruppeDTeams();
        var kommendeSpieleD = await _gruppenPhaseRepository.GetKommendeGruppeDSpiele();
        var vergangeneSpieleD = await _gruppenPhaseRepository.GetVergangeneGruppeDSpiele();

        var gruppenPhaseVm = new GruppenPhaseViewModel
        {
            GruppeDTeams = teamsD,
            KommendeGruppeDSpiele = kommendeSpieleD,
            VergangeneGruppeDSpiele = vergangeneSpieleD
        };
        return View(gruppenPhaseVm);
    }
    
    public async Task<IActionResult> GruppeE()
    {
        var teamsE = await _gruppenPhaseRepository.GetGruppeETeams();
        var kommendeSpieleE = await _gruppenPhaseRepository.GetKommendeGruppeESpiele();
        var vergangeneSpieleE = await _gruppenPhaseRepository.GetVergangeneGruppeESpiele();

        var gruppenPhaseVm = new GruppenPhaseViewModel
        {
            GruppeETeams = teamsE,
            KommendeGruppeESpiele = kommendeSpieleE,
            VergangeneGruppeESpiele = vergangeneSpieleE
        };
        return View(gruppenPhaseVm);
    }
    
    public async Task<IActionResult> GruppeF()
    {
        var teamsF = await _gruppenPhaseRepository.GetGruppeFTeams();
        var kommendeSpieleF = await _gruppenPhaseRepository.GetKommendeGruppeFSpiele();
        var vergangeneSpieleF = await _gruppenPhaseRepository.GetVergangeneGruppeFSpiele();

        var gruppenPhaseVm = new GruppenPhaseViewModel
        {
            GruppeFTeams = teamsF,
            KommendeGruppeFSpiele = kommendeSpieleF,
            VergangeneGruppeFSpiele = vergangeneSpieleF
        };
        return View(gruppenPhaseVm);
    }
    
    public async Task<IActionResult> GruppeG()
    {
        var teamsG = await _gruppenPhaseRepository.GetGruppeGTeams();
        var kommendeSpieleG = await _gruppenPhaseRepository.GetKommendeGruppeGSpiele();
        var vergangeneSpieleG = await _gruppenPhaseRepository.GetVergangeneGruppeGSpiele();

        var gruppenPhaseVm = new GruppenPhaseViewModel
        {
            GruppeGTeams = teamsG,
            KommendeGruppeGSpiele = kommendeSpieleG,
            VergangeneGruppeGSpiele = vergangeneSpieleG
        };
        return View(gruppenPhaseVm);
    }
}