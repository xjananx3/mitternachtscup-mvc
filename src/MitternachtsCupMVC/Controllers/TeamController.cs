using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MitternachtsCupMVC.Data;
using MitternachtsCupMVC.Interfaces;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC.Controllers;

public class TeamController : Controller
{
    private readonly ITeamRepository _teamRepository;

    public TeamController(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }
    public async Task<IActionResult> Index()
    {
        var teams = await _teamRepository.GetAll();
        return View(teams);
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Team team)
    {
        if (!ModelState.IsValid)
        {
            return View(team);
        }
        
        _teamRepository.Add(team);
        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> Edit(int id)
    {
        var team = await _teamRepository.GetByIdAsync(id);
        if (team == null) return View("Error");

        var teamVm = new EditTeamViewModel()
        {
            Name = team.Name
        };
        return View(teamVm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, EditTeamViewModel teamVm)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Fehler beim bearbeiten des Teams");
        }

        var team = new Team()
        {
            Id = id,
            Name = teamVm.Name
        };
        _teamRepository.Update(team);
        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        var teamDetails = await _teamRepository.GetByIdAsync(id);
        if (teamDetails == null) return View("Error");
        return View(teamDetails);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteTeam(int id)
    {
        var teamDetails = await _teamRepository.GetByIdAsync(id);
        if (teamDetails == null) return View("Error");

        _teamRepository.Delete(teamDetails);
        return RedirectToAction("Index");
    }
}