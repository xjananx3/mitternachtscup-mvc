using Microsoft.EntityFrameworkCore;
using MitternachtsCupMVC.Data;
using MitternachtsCupMVC.Interfaces;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC.Repository;

public class GruppenAnzeigeRepository : IGruppenAnzeigeRepository
{
    private readonly ApplicationDbContext _context;

    public GruppenAnzeigeRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<TeamInGruppe>> GetGruppeATeams()
    {
        return await GetGruppeTeams("Gruppe A");
    }

    public async Task<IEnumerable<GruppenSpielTurnierPlan>> GetKommendeGruppeASpiele()
    {
        return await GetGruppeKommendeSpiele("Gruppe A");
    }

    public async Task<IEnumerable<GruppenSpielTurnierPlan>> GetVergangeneGruppeASpiele()
    {
        return await GetGruppeVergangeneSpiele("Gruppe A");
    }

    public async Task<IEnumerable<TeamInGruppe>> GetGruppeBTeams()
    {
        return await GetGruppeTeams("Gruppe B");
    }

    public async Task<IEnumerable<GruppenSpielTurnierPlan>> GetKommendeGruppeBSpiele()
    {
        return await GetGruppeKommendeSpiele("Gruppe B");
    }

    public async Task<IEnumerable<GruppenSpielTurnierPlan>> GetVergangeneGruppeBSpiele()
    {
        return await GetGruppeVergangeneSpiele("Gruppe B");
    }
    

    public async Task<IEnumerable<TeamInGruppe>> GetGruppeCTeams()
    {
        return await GetGruppeTeams("Gruppe C");
    }

    public async Task<IEnumerable<GruppenSpielTurnierPlan>> GetKommendeGruppeCSpiele()
    {
        return await GetGruppeKommendeSpiele("Gruppe C");
    }

    public async Task<IEnumerable<GruppenSpielTurnierPlan>> GetVergangeneGruppeCSpiele()
    {
        return await GetGruppeVergangeneSpiele("Gruppe C");
    }

    public async Task<IEnumerable<TeamInGruppe>> GetGruppeDTeams()
    {
        return await GetGruppeTeams("Gruppe D");
    }

    public async Task<IEnumerable<GruppenSpielTurnierPlan>> GetKommendeGruppeDSpiele()
    {
        return await GetGruppeKommendeSpiele("Gruppe D");
    }

    public async Task<IEnumerable<GruppenSpielTurnierPlan>> GetVergangeneGruppeDSpiele()
    {
        return await GetGruppeVergangeneSpiele("Gruppe D");
    }
    

    public async Task<IEnumerable<TeamInGruppe>> GetGruppeETeams()
    {
        return await GetGruppeTeams("Gruppe E");
    }

    public async Task<IEnumerable<GruppenSpielTurnierPlan>> GetKommendeGruppeESpiele()
    {
        return await GetGruppeKommendeSpiele("Gruppe E");
    }

    public async Task<IEnumerable<GruppenSpielTurnierPlan>> GetVergangeneGruppeESpiele()
    {
        return await GetGruppeVergangeneSpiele("Gruppe E");
    }
    

    public async Task<IEnumerable<TeamInGruppe>> GetGruppeFTeams()
    {
        return await GetGruppeTeams("Gruppe F");
    }

    public async Task<IEnumerable<GruppenSpielTurnierPlan>> GetKommendeGruppeFSpiele()
    {
        return await GetGruppeKommendeSpiele("Gruppe F");
    }

    public async Task<IEnumerable<GruppenSpielTurnierPlan>> GetVergangeneGruppeFSpiele()
    {
        return await GetGruppeVergangeneSpiele("Gruppe F");
    }

    public async Task<IEnumerable<TeamInGruppe>> GetGruppeGTeams()
    {
        return await GetGruppeTeams("Gruppe G");
    }

    public async Task<IEnumerable<GruppenSpielTurnierPlan>> GetKommendeGruppeGSpiele()
    {
        return await GetGruppeKommendeSpiele("Gruppe G");
    }

    public async Task<IEnumerable<GruppenSpielTurnierPlan>> GetVergangeneGruppeGSpiele()
    {
        return await GetGruppeVergangeneSpiele("Gruppe G");
    }
    

    private async Task<IEnumerable<TeamInGruppe>> GetGruppeTeams(string gruppenName)
    {
        var spiele = await _context.Spiele
            .Where(s => s.Name.Contains(gruppenName))
            .ToListAsync();

        var teamIds = spiele
            .SelectMany(s => new[] { s.TeamAId, s.TeamBId })
            .Distinct();
        
        var teams = await _context.Teams
            .Where(t => teamIds.Contains(t.Id))
            .ToListAsync();

        var teamsInGruppe = teams
            .Select(t => new TeamInGruppe
            {
                Id = t.Id,
                Name = t.Name
            })
            .ToList();

        return teamsInGruppe;
    }

    private async Task<IEnumerable<GruppenSpielTurnierPlan>> GetGruppeKommendeSpiele(string gruppenName)
    {
        var ergebnisse = await _context.Ergebnisse.ToListAsync();
        var teams = await _context.Teams.ToListAsync();

        var spiele = await _context.Spiele
            .Where(s => s.Name.Contains(gruppenName))
            .ToListAsync();

        var spieleOhneErgebnis = spiele
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
        

        return spieleOhneErgebnis;
    }
    
    private async Task<IEnumerable<GruppenSpielTurnierPlan>> GetGruppeVergangeneSpiele(string gruppenName)
    {
        var ergebnisse = await _context.Ergebnisse.ToListAsync();
        var teams = await _context.Teams.ToListAsync();
        
        var spiele = await _context.Spiele
            .Where(s => s.Name.Contains(gruppenName))
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

                return new GruppenSpielTurnierPlan
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
    
    private string ErgebnisAufbereiten(int punkteA, int punkteB)
    {
        return $"{punkteA} : {punkteB}";
    }
}