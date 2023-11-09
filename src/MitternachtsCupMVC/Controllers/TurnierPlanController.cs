using Microsoft.AspNetCore.Mvc;
using MitternachtsCupMVC.Interfaces;

namespace MitternachtsCupMVC.Controllers;

public class TurnierPlanController : Controller
{
    private readonly ITeamRepository _teamRepository;
    private readonly ISpielRepository _spielRepository;

    public TurnierPlanController(ITeamRepository teamRepository, ISpielRepository spielRepository)
    {
        _teamRepository = teamRepository;
        _spielRepository = spielRepository;
    }
    public async Task<IActionResult> Index()
    {
        var teams = await _teamRepository.GetAll();
        var spiele = await _spielRepository.GetAll();
        
        var turnierplanViewModel = new TurnierplanViewModel()
        {
            Spiele = spiele,
            Teams = teams
        };
        return View(turnierplanViewModel);
    }
}