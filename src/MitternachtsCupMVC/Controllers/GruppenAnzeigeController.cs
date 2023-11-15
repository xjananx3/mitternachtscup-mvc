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
        var teams = await _gruppenAnzeigeRepository.GetGruppeATeams();

        var gruppenAnzeigeVm = new GruppenAnzeigeViewModel()
        {
            GruppeATeams = teams,
        };
        
        return View(gruppenAnzeigeVm);
    }
}