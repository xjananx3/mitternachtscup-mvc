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
        var spiele = await _context.Spiele
            .Where(s => s.Name.Contains("Gruppe A"))
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

    public Task<IEnumerable<GruppenSpielTurnierPlan>> GetGruppeASpiele()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TeamInGruppe>> GetGruppeBTeams()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GruppenSpielTurnierPlan>> GetGruppeBSpiele()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TeamInGruppe>> GetGruppeCTeams()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GruppenSpielTurnierPlan>> GetGruppeCSpiele()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TeamInGruppe>> GetGruppeDTeams()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GruppenSpielTurnierPlan>> GetGruppeDSpiele()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TeamInGruppe>> GetGruppeETeams()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GruppenSpielTurnierPlan>> GetGruppeESpiele()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TeamInGruppe>> GetGruppeFTeams()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GruppenSpielTurnierPlan>> GetGruppeFSpiele()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TeamInGruppe>> GetGruppeGTeams()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<GruppenSpielTurnierPlan>> GetGruppeGSpiele()
    {
        throw new NotImplementedException();
    }
}