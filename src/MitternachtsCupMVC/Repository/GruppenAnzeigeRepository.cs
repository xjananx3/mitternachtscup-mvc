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

    public Task<IEnumerable<GruppenSpielTurnierPlan>> GetGruppeASpiele()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TeamInGruppe>> GetGruppeBTeams()
    {
        return await GetGruppeTeams("Gruppe B");
    }

    public Task<IEnumerable<GruppenSpielTurnierPlan>> GetGruppeBSpiele()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TeamInGruppe>> GetGruppeCTeams()
    {
        return await GetGruppeTeams("Gruppe C");
    }

    public Task<IEnumerable<GruppenSpielTurnierPlan>> GetGruppeCSpiele()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TeamInGruppe>> GetGruppeDTeams()
    {
        return await GetGruppeTeams("Gruppe D");
    }

    public Task<IEnumerable<GruppenSpielTurnierPlan>> GetGruppeDSpiele()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TeamInGruppe>> GetGruppeETeams()
    {
        return await GetGruppeTeams("Gruppe E");
    }

    public Task<IEnumerable<GruppenSpielTurnierPlan>> GetGruppeESpiele()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TeamInGruppe>> GetGruppeFTeams()
    {
        return await GetGruppeTeams("Gruppe F");
    }

    public Task<IEnumerable<GruppenSpielTurnierPlan>> GetGruppeFSpiele()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TeamInGruppe>> GetGruppeGTeams()
    {
        return await GetGruppeTeams("Gruppe G");
    }

    public Task<IEnumerable<GruppenSpielTurnierPlan>> GetGruppeGSpiele()
    {
        throw new NotImplementedException();
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
}