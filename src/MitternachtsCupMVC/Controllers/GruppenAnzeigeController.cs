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
        var teamsB = await _gruppenAnzeigeRepository.GetGruppeBTeams();
        var teamsC = await _gruppenAnzeigeRepository.GetGruppeCTeams();
        var teamsD = await _gruppenAnzeigeRepository.GetGruppeDTeams();
        var teamsE = await _gruppenAnzeigeRepository.GetGruppeETeams();
        var teamsF = await _gruppenAnzeigeRepository.GetGruppeFTeams();
        var teamsG = await _gruppenAnzeigeRepository.GetGruppeGTeams();

        var gruppenAnzeigeVm = new GruppenAnzeigeViewModel()
        {
            GruppeATeams = teamsA,
            GruppeBTeams = teamsB,
            GruppeCTeams = teamsC,
            GruppeDTeams = teamsD,
            GruppeETeams = teamsE,
            GruppeFTeams = teamsF,
            GruppeGTeams = teamsG
        };
        
        return View(gruppenAnzeigeVm);
    }
}