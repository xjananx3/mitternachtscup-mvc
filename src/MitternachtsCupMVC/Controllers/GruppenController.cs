using Microsoft.AspNetCore.Mvc;
using MitternachtsCupMVC.Interfaces;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC.Controllers;

public class GruppenController : Controller
{
    private readonly IGruppenRepository _gruppenRepository;

    public GruppenController(IGruppenRepository gruppenRepository)
    {
        _gruppenRepository = gruppenRepository;
    }
    
    public async Task<IActionResult> GruppeA()
    {
        var gruppeAteams = await _gruppenRepository.GetGruppeA();
        
        return View(gruppeAteams);
    }
    
    public async Task<IActionResult> GruppeB()
    {
        var gruppeBteams = await _gruppenRepository.GetGruppeB();
        
        return View(gruppeBteams);
    }
    
    public async Task<IActionResult> GruppeC()
    {
        var gruppeCteams = await _gruppenRepository.GetGruppeC();
        
        return View(gruppeCteams);
    }
    
    public async Task<IActionResult> GruppeD()
    {
        var gruppeDteams = await _gruppenRepository.GetGruppeD();
        
        return View(gruppeDteams);
    }
    
    
}