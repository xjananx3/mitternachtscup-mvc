using Microsoft.AspNetCore.Mvc;
using MitternachtsCupMVC.Data;
using MitternachtsCupMVC.Interfaces;

namespace MitternachtsCupMVC.Controllers;

public class KoPhaseController : Controller
{
    private readonly IKoPhaseRepository _koPhaseRepository;

    public KoPhaseController(IKoPhaseRepository koPhaseRepository)
    {
        _koPhaseRepository = koPhaseRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var kommendeAchtelfinals = await _koPhaseRepository.GetKommendeAchtelfinals();
        var vergangeneAchtelfinals = await _koPhaseRepository.GetVergangeneAchtelfinals();

        var kommendeViertelfinals = await _koPhaseRepository.GetKommendeViertelfinals();
        var vergangeneViertelfinals = await _koPhaseRepository.GetVergangeneViertelfinals();

        var kommendeHalbfinals = await _koPhaseRepository.GetKommendeHalbfinals();
        var vergangeneHalbfinals = await _koPhaseRepository.GetVergangeneHalbfinals();
        
        var spielUmPlatz3 = await _koPhaseRepository.GetSpielUmPlatz3() ?? new KoSpiel();
        var finale = await _koPhaseRepository.GetFinale() ?? new KoSpiel(); 
        
        var koPhaseVm = new IndexKoPhaseViewModel()
        {
            KommendeAchtelfinals = kommendeAchtelfinals,
            VergangeneAchtelfinals = vergangeneAchtelfinals,
            KommendeViertelfinals = kommendeViertelfinals,
            VergangeneViertelfinals = vergangeneViertelfinals,
            KommendeHalbfinals = kommendeHalbfinals,
            VergangeneHalbfinals = vergangeneHalbfinals,
            SpielUmPlatz3 = spielUmPlatz3,
            Finale = finale
        };
        
        return View(koPhaseVm);
    }

    public async Task<IActionResult> Achtelfinale()
    {
        var kommendeAchtelfinals = await _koPhaseRepository.GetKommendeAchtelfinals();
        var vergangeneAchtelfinals = await _koPhaseRepository.GetVergangeneAchtelfinals();

        var koPhaseVm = new KoPhaseViewModel
        {
            KommendeKoSpiele = kommendeAchtelfinals,
            VergangeneKoSpiele = vergangeneAchtelfinals
        };

        return View(koPhaseVm);
    }

    public async Task<IActionResult> Viertelfinale()
    {
        var kommendeViertelfinals = await _koPhaseRepository.GetKommendeViertelfinals();
        var vergangeneViertelfinals = await _koPhaseRepository.GetVergangeneViertelfinals();

        var koPhaseVm = new KoPhaseViewModel
        {
            KommendeKoSpiele = kommendeViertelfinals,
            VergangeneKoSpiele = vergangeneViertelfinals
        };
        
        return View(koPhaseVm);
    }

    public async Task<IActionResult> Halbfinale()
    {
        var kommendeHalbfinals = await _koPhaseRepository.GetKommendeHalbfinals();
        var vergangeneHalbfinals = await _koPhaseRepository.GetVergangeneHalbfinals();
        

        var koPhaseVm = new KoPhaseViewModel
        {
            KommendeKoSpiele = kommendeHalbfinals,
            VergangeneKoSpiele = vergangeneHalbfinals
        };
        
        return View(koPhaseVm);
    }

    public async Task<IActionResult> SpielUmPlatz3()
    {
        var spielUmPlatz3 = await _koPhaseRepository.GetSpielUmPlatz3();

        if (spielUmPlatz3 != null)
        {
            var finalSpielVm = new FinalSpielViewModel()
            {
                Platte = spielUmPlatz3.Platte,
                SpielName = spielUmPlatz3.SpielName,
                StartZeit = spielUmPlatz3.StartZeit,
                TeamAName = spielUmPlatz3.TeamAName,
                TeamBName = spielUmPlatz3.TeamBName,
                Ergebnis = spielUmPlatz3.Ergebnis,
                GewinnerName = spielUmPlatz3.GewinnerName
            };
            
            return View(finalSpielVm);
        }

        return View("NichtVerfuegbar");
    }

    public async Task<IActionResult> Finale()
    {
        var finale = await _koPhaseRepository.GetFinale();
        
        if(finale != null)
        {
            var finalSpielVm = new FinalSpielViewModel()
            {
                Platte = finale.Platte,
                SpielName = finale.SpielName,
                StartZeit = finale.StartZeit,
                TeamAName = finale.TeamAName,
                TeamBName = finale.TeamBName,
                Ergebnis = finale.Ergebnis,
                GewinnerName = finale.GewinnerName
            };
            
            return View(finalSpielVm);
        }

        return View("NichtVerfuegbar");
    }
}