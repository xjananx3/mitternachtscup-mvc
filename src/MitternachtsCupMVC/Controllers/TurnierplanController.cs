using Microsoft.AspNetCore.Mvc;
using MitternachtsCupMVC.Interfaces;

namespace MitternachtsCupMVC.Controllers;

public class TurnierplanController : Controller
{
    private readonly ITurnierplanRepository _turnierplanRepository;

    public TurnierplanController(ITurnierplanRepository turnierplanRepository)
    {
        _turnierplanRepository = turnierplanRepository;
    }
    public async Task<IActionResult> Index()
    {
        var spieleMitErgebnis = await _turnierplanRepository.HoleSpieleMitErgebnis();
        var spielOhneErgebnis = await _turnierplanRepository.HoleSpieleOhneErgebnis();

        var turnierplanVm = new TurnierplanViewModel()
        {
            GruppenSpieleMitErgebnis = spieleMitErgebnis,
            GruppenSpieleOhneErgebnis = spielOhneErgebnis
        };
        return View(turnierplanVm);
    }
}