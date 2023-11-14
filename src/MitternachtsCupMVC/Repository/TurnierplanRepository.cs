using Microsoft.EntityFrameworkCore;
using MitternachtsCupMVC.Data;
using MitternachtsCupMVC.Interfaces;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC.Repository;

public class TurnierplanRepository : ITurnierplanRepository
{
    private readonly ApplicationDbContext _context;
    
    public TurnierplanRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<ICollection<GruppenSpielTurnierPlan>> HoleSpieleMitErgebnis()
    {
        var spiele = await _context.Spiele.ToListAsync();
        var ergebnisse = await _context.Ergebnisse.ToListAsync();
        var teams = await _context.Teams.ToListAsync();
        
        var gruppenSpielListe = spiele
            .Join(ergebnisse,
                s => s.Id,
                e => e.SpielId,
                (spiel, ergebnis) => new { Spiel = spiel, Ergebnis = ergebnis })
            .Select(item =>
            {
                var teamA = teams.FirstOrDefault(t => t.Id == item.Spiel.TeamAId);
                var teamB = teams.FirstOrDefault(t => t.Id == item.Spiel.TeamBId);

                return new GruppenSpielTurnierPlan()
                {
                    Platte = item.Spiel.Platte.ToString(),
                    SpielName = item.Spiel.Name,
                    TeamAName = teamA?.Name,
                    TeamBName = teamB?.Name,
                    Ergebnis = ErgebnisAufbereiten(item.Ergebnis.PunkteTeamA, item.Ergebnis.PunkteTeamB),
                    GewinnerName = item.Ergebnis.PunkteTeamA > item.Ergebnis.PunkteTeamB ? teamA?.Name : teamB?.Name
                };
            }).ToList();
        
        return gruppenSpielListe;
    }

    public async Task<ICollection<GruppenSpielTurnierPlan>> HoleSpieleOhneErgebnis()
    {
        var spiele = await _context.Spiele.ToListAsync();
        var ergebnisse = await _context.Ergebnisse.ToListAsync();
        var teams = await _context.Teams.ToListAsync();

        var gruppenspieleOhneErgebnis = spiele
            .Where(s => !ergebnisse.Any(e => e.SpielId == s.Id))
            .Select(spiel => new GruppenSpielTurnierPlan()
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

        return gruppenspieleOhneErgebnis;
    }

    private string ErgebnisAufbereiten(int punkteA, int punkteB)
    {
        return $"{punkteA} : {punkteB}";
    }
}