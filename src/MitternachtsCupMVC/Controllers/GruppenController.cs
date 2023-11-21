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

    public async Task<IActionResult> Index()
    {
        var gruppeA = await _gruppenRepository.ErstelleSpieleGruppeA();
        var gruppeB = await _gruppenRepository.ErstelleSpieleGruppeB();
        var gruppeC = await _gruppenRepository.ErstelleSpieleGruppeC();
        var gruppeD = await _gruppenRepository.ErstelleSpieleGruppeD();
        var gruppeE = await _gruppenRepository.ErstelleSpieleGruppeE();
        var gruppeF = await _gruppenRepository.ErstelleSpieleGruppeF();
        var gruppeG = await _gruppenRepository.ErstelleSpieleGruppeG();

        var gruppenVm = new IndexGruppenViewModel()
        {
            GruppeASpiele = gruppeA,
            GruppeBSpiele = gruppeB,
            GruppeCSpiele = gruppeC,
            GruppeDSpiele = gruppeD,
            GruppeESpiele = gruppeE,
            GruppeFSpiele = gruppeF,
            GruppeGSpiele = gruppeG
        };

        return View(gruppenVm);
    }

    public async Task<IActionResult> AlleGruppen()
    {
        var gruppeAteams = await _gruppenRepository.GetGruppeA();
        var gruppeBteams = await _gruppenRepository.GetGruppeB();
        var gruppeCteams = await _gruppenRepository.GetGruppeC();
        var gruppeDteams = await _gruppenRepository.GetGruppeD();
        var gruppeEteams = await _gruppenRepository.GetGruppeE();
        var gruppeFteams = await _gruppenRepository.GetGruppeF();
        var gruppeGteams = await _gruppenRepository.GetGruppeG();

        var alleGruppenVm = new AlleGruppenViewModel
        {
            GruppeA = gruppeAteams,
            GruppeB = gruppeBteams,
            GruppeC = gruppeCteams,
            GruppeD = gruppeDteams,
            GruppeE = gruppeEteams,
            GruppeF = gruppeFteams,
            GruppeG = gruppeGteams
        };

        return View(alleGruppenVm);
    }
    public async Task<IActionResult> GruppeA()
    {
        var gruppeAteams = await _gruppenRepository.GetGruppeA();
        var gruppenSpiele = await _gruppenRepository.ErstelleSpieleGruppeA();

        var gruppenVm = new GruppenViewModel()
        {
            Teams = gruppeAteams,
            GruppenSpiele = gruppenSpiele
        };
        return View(gruppenVm);
    }
    
    public async Task<IActionResult> GruppeB()
    {
        var gruppeBteams = await _gruppenRepository.GetGruppeB();
        var gruppenSpiele = await _gruppenRepository.ErstelleSpieleGruppeB();

        var gruppenVm = new GruppenViewModel()
        {
            Teams = gruppeBteams,
            GruppenSpiele = gruppenSpiele
        };
        return View(gruppenVm);
    }
    
    public async Task<IActionResult> GruppeC()
    {
        var gruppeCteams = await _gruppenRepository.GetGruppeC();
        var gruppenSpiele = await _gruppenRepository.ErstelleSpieleGruppeC();

        var gruppenVm = new GruppenViewModel()
        {
            Teams = gruppeCteams,
            GruppenSpiele = gruppenSpiele
        };
        return View(gruppenVm);
    }
    
    public async Task<IActionResult> GruppeD()
    {
        var gruppeDteams = await _gruppenRepository.GetGruppeD();
        var gruppenSpiele = await _gruppenRepository.ErstelleSpieleGruppeD();

        var gruppenVm = new GruppenViewModel()
        {
            Teams = gruppeDteams,
            GruppenSpiele = gruppenSpiele
        };
        return View(gruppenVm);
    }
    
    public async Task<IActionResult> GruppeE()
    {
        var gruppeEteams = await _gruppenRepository.GetGruppeE();
        var gruppenSpiele = await _gruppenRepository.ErstelleSpieleGruppeE();

        var gruppenVm = new GruppenViewModel()
        {
            Teams = gruppeEteams,
            GruppenSpiele = gruppenSpiele
        };
        return View(gruppenVm);
    }
    
    public async Task<IActionResult> GruppeF()
    {
        var gruppeFteams = await _gruppenRepository.GetGruppeF();
        var gruppenSpiele = await _gruppenRepository.ErstelleSpieleGruppeF();

        var gruppenVm = new GruppenViewModel()
        {
            Teams = gruppeFteams,
            GruppenSpiele = gruppenSpiele
        };
        return View(gruppenVm);
    }
    
    public async Task<IActionResult> GruppeG()
    {
        var gruppeGteams = await _gruppenRepository.GetGruppeG();
        var gruppenSpiele = await _gruppenRepository.ErstelleSpieleGruppeG();

        var gruppenVm = new GruppenViewModel()
        {
            Teams = gruppeGteams,
            GruppenSpiele = gruppenSpiele
        };
        return View(gruppenVm);
    }
    
}