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
        var gruppenSpielListe = new List<GruppenSpielTurnierPlan>();
        string teamAName = String.Empty;
        string teamBName = String.Empty;
        string gewinnerName = String.Empty;
        string ergebnisString = String.Empty;

        foreach (var spiel in spiele)
        {
            foreach (var ergebnis in ergebnisse)
            {
                if (spiel.Id == ergebnis.SpielId)
                {
                    var teamA = teams.FirstOrDefault(t => t.Id == spiel.TeamAId);
                    var teamB = teams.FirstOrDefault(t => t.Id == spiel.TeamBId);
                    teamAName = teamA.Name;
                    teamBName = teamB.Name;
                    ergebnisString = ErgebnisAufbereiten(ergebnis.PunkteTeamA, ergebnis.PunkteTeamB);

                    if (ergebnis.PunkteTeamA > ergebnis.PunkteTeamB)
                    {
                        gewinnerName = teamAName;
                    }
                    else
                    {
                        gewinnerName = teamBName;
                    }
                    
                    var gruppenSpiel = new GruppenSpielTurnierPlan()
                    {
                        Platte = spiel.Platte.ToString(),
                        SpielName = spiel.Name,
                        TeamAName = teamAName,
                        TeamBName = teamBName,
                        Ergebnis = ergebnisString,
                        GewinnerName = gewinnerName
                    };
                    gruppenSpielListe.Add(gruppenSpiel);
                }
            }
        }

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
                SpielName = spiel.Name,
                StartZeit = spiel.StartZeit.ToString(),
                TeamAName = teams.FirstOrDefault(t => t.Id == spiel.TeamAId)?.Name,
                TeamBName = teams.FirstOrDefault(t => t.Id == spiel.TeamBId)?.Name
            }).ToList();

        return gruppenspieleOhneErgebnis;
    }

    private string ErgebnisAufbereiten(int punkteA, int punkteB)
    {
        return $"{punkteA} : {punkteB}";
    }
}