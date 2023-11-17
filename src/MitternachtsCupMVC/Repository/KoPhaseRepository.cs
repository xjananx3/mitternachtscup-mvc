using Microsoft.EntityFrameworkCore;
using MitternachtsCupMVC.Data;
using MitternachtsCupMVC.Interfaces;

namespace MitternachtsCupMVC.Repository;

public class KoPhaseRepository : IKoPhaseRepository
{
    private readonly ApplicationDbContext _context;

    public KoPhaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<KoSpiel>> GetKommendeAchtelfinals()
    {
        return await GetKommendeKoSpiele("Achtelfinale");
    }

    public async Task<IEnumerable<KoSpiel>> GetVergangeneAchtelfinals()
    {
        return await GetVergangeneKoSpiele("Achtelfinale");
    }

    public async Task<IEnumerable<KoSpiel>> GetKommendeViertelfinals()
    {
        return await GetKommendeKoSpiele("Viertelfinale");
    }

    public async Task<IEnumerable<KoSpiel>> GetVergangeneViertelfinals()
    {
        return await GetVergangeneKoSpiele("Viertelfinale");
    }

    public async Task<IEnumerable<KoSpiel>> GetKommendeHalbfinals()
    {
        return await GetKommendeKoSpiele("Halbfinale");
    }

    public async Task<IEnumerable<KoSpiel>> GetVergangeneHalbfinals()
    {
        return await GetVergangeneKoSpiele("Halbfinale");
    }

    public async Task<KoSpiel> GetFinale()
    {
        return await GetFinalSpiel("Finale");
    }

    public async Task<KoSpiel> GetSpielUmPlatz3()
    {
        return await GetFinalSpiel("Spiel um Platz 3");
    }

    private async Task<IEnumerable<KoSpiel>> GetKommendeKoSpiele(string koSpielName)
    {
        var ergebnisse = await _context.Ergebnisse.ToListAsync();
        var teams = await _context.Teams.ToListAsync();

        var spiele = await _context.Spiele
            .Where(s => s.Name.Contains(koSpielName))
            .ToListAsync();

        var spielOhneErgebnis = spiele
            .Where(s => !ergebnisse.Any(e => e.SpielId == s.Id))
            .Select(spiel => new KoSpiel
            {
                Platte = spiel.Platte.ToString(),
                SpielId = spiel.Id,
                SpielName = spiel.Name,
                StartZeit = spiel.StartZeit.ToString(),
                TeamAId = teams.FirstOrDefault(t => t.Id == spiel.TeamAId)?.Id,
                TeamAName = teams.FirstOrDefault(t => t.Id == spiel.TeamAId)?.Name,
                TeamBId = teams.FirstOrDefault(t => t.Id == spiel.TeamBId)?.Id,
                TeamBName = teams.FirstOrDefault(t => t.Id == spiel.TeamBId)?.Name
            }).ToList();

        return spielOhneErgebnis;
    }

    private async Task<IEnumerable<KoSpiel>> GetVergangeneKoSpiele(string koSpielName)
    {
        var ergebnisse = await _context.Ergebnisse.ToListAsync();
        var teams = await _context.Teams.ToListAsync();
        
        var spiele = await _context.Spiele
            .Where(s => s.Name.Contains(koSpielName))
            .ToListAsync();

        var spieleMitErgebnis = spiele
            .Join(ergebnisse,
                s => s.Id,
                e => e.SpielId,
                (spiel, ergebnis) => new { Spiel = spiel, Ergebnis = ergebnis })
            .Select(item =>
            {
                var teamA = teams.FirstOrDefault(t => t.Id == item.Spiel.TeamAId);
                var teamB = teams.FirstOrDefault(t => t.Id == item.Spiel.TeamBId);

                return new KoSpiel
                {
                    Platte = item.Spiel.Platte.ToString(),
                    SpielName = item.Spiel.Name,
                    TeamAName = teamA?.Name,
                    TeamBName = teamB?.Name,
                    Ergebnis = ErgebnisAufbereiten(item.Ergebnis.PunkteTeamA, item.Ergebnis.PunkteTeamB),
                    GewinnerName = item.Ergebnis.PunkteTeamA > item.Ergebnis.PunkteTeamB ? teamA?.Name : teamB?.Name
                };
            }).ToList();

        return spieleMitErgebnis;
    }

    private async Task<KoSpiel> GetFinalSpiel(string spielName)
    {
        var spiel = await _context.Spiele.FirstOrDefaultAsync(s => s.Name.Contains(spielName));

        if (spiel != null)
        {
            var ergebnis = await _context.Ergebnisse.FirstOrDefaultAsync(e => e.SpielId == spiel.Id);
            var teams = await _context.Teams.ToListAsync();

            if (ergebnis != null)
            {
                var teamA = teams.FirstOrDefault(t => t.Id == spiel.TeamAId);
                var teamB = teams.FirstOrDefault(t => t.Id == spiel.TeamBId);

                return new KoSpiel
                {
                    Platte = spiel.Platte.ToString(),
                    SpielId = spiel.Id,
                    SpielName = spiel.Name,
                    StartZeit = spiel.StartZeit.ToString(),
                    TeamAId = teamA?.Id,
                    TeamAName = teamA?.Name,
                    TeamBId = teamB?.Id,
                    TeamBName = teamB?.Name,
                    Ergebnis = ErgebnisAufbereiten(ergebnis.PunkteTeamA, ergebnis.PunkteTeamB),
                    GewinnerName = ergebnis.PunkteTeamA > ergebnis.PunkteTeamB ? teamA?.Name : teamB?.Name
                };
            }
            else
            {
                return new KoSpiel
                {
                    Platte = spiel.Platte.ToString(),
                    SpielId = spiel.Id,
                    SpielName = spiel.Name,
                    StartZeit = spiel.StartZeit.ToString(),
                    TeamAId = teams.FirstOrDefault(t => t.Id == spiel.TeamAId)?.Id,
                    TeamAName = teams.FirstOrDefault(t => t.Id == spiel.TeamAId)?.Name,
                    TeamBId = teams.FirstOrDefault(t => t.Id == spiel.TeamBId)?.Id,
                    TeamBName = teams.FirstOrDefault(t => t.Id == spiel.TeamBId)?.Name
                };
            }
        }

        return null;
    }
    
    private string ErgebnisAufbereiten(int punkteA, int punkteB)
    {
        return $"{punkteA} : {punkteB}";
    }
}
