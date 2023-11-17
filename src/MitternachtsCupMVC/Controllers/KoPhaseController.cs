using Microsoft.AspNetCore.Mvc;
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

        var spielUmPlatz3 = await _koPhaseRepository.GetSpielUmPlatz3();
        var finale = await _koPhaseRepository.GetFinale();

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
}