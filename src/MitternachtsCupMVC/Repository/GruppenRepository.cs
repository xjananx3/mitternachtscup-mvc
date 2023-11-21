using Microsoft.EntityFrameworkCore;
using MitternachtsCupMVC.Data;
using MitternachtsCupMVC.Interfaces;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC.Repository;

public class GruppenRepository : IGruppenRepository
{
    private readonly ApplicationDbContext _context;

    public GruppenRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    

    public async Task<IEnumerable<Team>> GetGruppeA()
    {
        return await _context.Teams
            .Where(t => t.Name == "Bohnenklopfer 1"
                        || t.Name == "Durschdlöscher"
                        || t.Name == "MaLongSom"
                        || t.Name == "Larios 1").ToListAsync();
    }
    
    public async Task<ICollection<GruppenSpiel>> ErstelleSpieleGruppeA()
    {
        var gruppeAteams = await GetGruppeA();
        var gruppeA = gruppeAteams.ToList();

        var alleSpiele = GeneriereGruppenSpiele(gruppeA);

        return alleSpiele;
    }

    public async Task<IEnumerable<Team>> GetGruppeB()
    {
        return await _context.Teams
            .Where(t => t.Name == "Bohnenklopfer 2"
                        || t.Name == "RSkaliert"
                        || t.Name == "Spritzer"
                        || t.Name == "Rieder Piraten 1").ToListAsync();
    }
    
    public async Task<ICollection<GruppenSpiel>> ErstelleSpieleGruppeB()
    {
        var gruppeBteams = await GetGruppeB();
        var gruppeB = gruppeBteams.ToList();

        var alleSpiele = GeneriereGruppenSpiele(gruppeB);

        return alleSpiele;
    }

    public async Task<IEnumerable<Team>> GetGruppeC()
    {
        return await _context.Teams
            .Where(t => t.Name == "Larios 2"
                        || t.Name == "Schluchhalder"
                        || t.Name == "Schmetterball"
                        || t.Name == "Musikverein Sasbachried").ToListAsync();
    }
    
    public async Task<ICollection<GruppenSpiel>> ErstelleSpieleGruppeC()
    {
        var gruppeCteams = await GetGruppeC();
        var gruppeC = gruppeCteams.ToList();

        var alleSpiele = GeneriereGruppenSpiele(gruppeC);

        return alleSpiele;
    }

    public async Task<IEnumerable<Team>> GetGruppeD()
    {
        return await _context.Teams
            .Where(t => t.Name == "Rieder Piraten 2"
                        || t.Name == "Maflotho"
                        || t.Name == "The Old Schmetterhänds"
                        || t.Name == "OlympAllstars").ToListAsync();
    }
    
    public async Task<ICollection<GruppenSpiel>> ErstelleSpieleGruppeD()
    {
        var gruppeDteams = await GetGruppeD();
        var gruppeD = gruppeDteams.ToList();

        var alleSpiele = GeneriereGruppenSpiele(gruppeD);

        return alleSpiele;
    }
    
    public async Task<IEnumerable<Team>> GetGruppeE()
    {
        return await _context.Teams
            .Where(t => t.Name == "Geschwister Bauer"
                        || t.Name == "Team Dobex"
                        || t.Name == "Jungspritzer"
                        || t.Name == "Bohnenklopfer 3").ToListAsync();
    }
    
    public async Task<ICollection<GruppenSpiel>> ErstelleSpieleGruppeE()
    {
        var gruppeEteams= await GetGruppeE();
        var gruppeE = gruppeEteams.ToList();

        var alleSpiele = GeneriereGruppenSpiele(gruppeE);

        return alleSpiele;
    }
    
    public async Task<IEnumerable<Team>> GetGruppeF()
    {
        return await _context.Teams
            .Where(t => t.Name == "Rheingoldstraße"
                        || t.Name == "Kräuterhexen"
                        || t.Name == "SoulEater"
                        || t.Name == "Team Havana").ToListAsync();
    }
    
    public async Task<ICollection<GruppenSpiel>> ErstelleSpieleGruppeF()
    {
        var gruppeFteams = await GetGruppeF();
        var gruppeF = gruppeFteams.ToList();

        var alleSpiele = GeneriereGruppenSpiele(gruppeF);

        return alleSpiele;
    }

    public async Task<IEnumerable<Team>> GetGruppeG()
    {
        return await _context.Teams
            .Where(t => t.Name == "Moorknechte Sasbachried"
                        || t.Name == "Bohnenklopferinas"
                        || t.Name == "Gruschtle"
                        || t.Name == "Schmetterlinge").ToListAsync();
    }
    
    public async Task<ICollection<GruppenSpiel>> ErstelleSpieleGruppeG()
    {
        var gruppeGteams = await GetGruppeG();
        var gruppeG = gruppeGteams.ToList();

        var alleSpiele = GeneriereGruppenSpiele(gruppeG);

        return alleSpiele;
    }

    private List<GruppenSpiel> GeneriereGruppenSpiele(List<Team> teams)
    {
        List<GruppenSpiel> gruppenSpiele = new List<GruppenSpiel>();
        HashSet<int> bereitsTeamA = new HashSet<int>();

        gruppenSpiele = teams.SelectMany((team, index) =>
            teams.Skip(index + 1).Select(otherTeam =>
            {
                if (bereitsTeamA.Contains(team.Id))
                {
                    return new GruppenSpiel() { TeamA = otherTeam, TeamB = team };
                }
                else if (bereitsTeamA.Contains(otherTeam.Id))
                {
                    return new GruppenSpiel() { TeamA = team, TeamB = otherTeam };
                }
                else
                {
                    bereitsTeamA.Add(team.Id);
                    return new GruppenSpiel() { TeamA = team, TeamB = otherTeam };
                }
            })
        ).ToList();

        return gruppenSpiele;
    }
}