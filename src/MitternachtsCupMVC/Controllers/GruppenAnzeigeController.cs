using Microsoft.AspNetCore.Mvc;
using MitternachtsCupMVC.Interfaces;
using MitternachtsCupMVC.Repository;

namespace MitternachtsCupMVC.Controllers;

public class GruppenAnzeigeController : Controller
{
    private readonly IGruppenAnzeigeRepository _gruppenAnzeigeRepository;

    public GruppenAnzeigeController(IGruppenAnzeigeRepository gruppenAnzeigeRepository)
    {
        _gruppenAnzeigeRepository = gruppenAnzeigeRepository;
    }
    public async Task<IActionResult> Index()
    {
        var teamsA = await _gruppenAnzeigeRepository.GetGruppeATeams();
        var kommendeSpieleA = await _gruppenAnzeigeRepository.GetKommendeGruppeASpiele();
        var vergangeneSpieleA = await _gruppenAnzeigeRepository.GetVergangeneGruppeASpiele();
        
        var teamsB = await _gruppenAnzeigeRepository.GetGruppeBTeams();
        var kommendeSpieleB = await _gruppenAnzeigeRepository.GetKommendeGruppeBSpiele();
        var vergangeneSpieleB = await _gruppenAnzeigeRepository.GetVergangeneGruppeBSpiele();
        
        var teamsC = await _gruppenAnzeigeRepository.GetGruppeCTeams();
        var kommendeSpieleC = await _gruppenAnzeigeRepository.GetKommendeGruppeCSpiele();
        var vergangeneSpieleC = await _gruppenAnzeigeRepository.GetVergangeneGruppeCSpiele();
        
        var teamsD = await _gruppenAnzeigeRepository.GetGruppeDTeams();
        var kommendeSpieleD = await _gruppenAnzeigeRepository.GetKommendeGruppeDSpiele();
        var vergangeneSpieleD = await _gruppenAnzeigeRepository.GetVergangeneGruppeDSpiele();
        
        var teamsE = await _gruppenAnzeigeRepository.GetGruppeETeams();
        var kommendeSpieleE = await _gruppenAnzeigeRepository.GetKommendeGruppeESpiele();
        var vergangeneSpieleE = await _gruppenAnzeigeRepository.GetVergangeneGruppeESpiele();
        
        var teamsF = await _gruppenAnzeigeRepository.GetGruppeFTeams();
        var kommendeSpieleF = await _gruppenAnzeigeRepository.GetKommendeGruppeFSpiele();
        var vergangeneSpieleF = await _gruppenAnzeigeRepository.GetVergangeneGruppeFSpiele();
        
        var teamsG = await _gruppenAnzeigeRepository.GetGruppeGTeams();
        var kommendeSpieleG = await _gruppenAnzeigeRepository.GetKommendeGruppeGSpiele();
        var vergangeneSpieleG = await _gruppenAnzeigeRepository.GetVergangeneGruppeGSpiele();

        var gruppenAnzeigeVm = new GruppenAnzeigeViewModel()
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
}