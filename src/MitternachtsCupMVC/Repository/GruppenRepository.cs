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
            .Where(t => t.Name == "Bohnenkloper 1"
                        || t.Name == "Durschdlöscher"
                        || t.Name == "MaLongSom"
                        || t.Name == "Test 123"
                        || t.Name == "Larios 1"
                        || t.Name == "Moorknechte Sasbachried").ToListAsync();
    }

    public async Task<IEnumerable<Team>> GetGruppeB()
    {
        return await _context.Teams
            .Where(t => t.Name == "Bohnenkloper 2"
                        || t.Name == "RSkaliert"
                        || t.Name == "Spritzer"
                        || t.Name == "Dummy Team 1"
                        || t.Name == "Rieder Piraten 1").ToListAsync();
    }

    public async Task<IEnumerable<Team>> GetGruppeC()
    {
        return await _context.Teams
            .Where(t => t.Name == "Larios 2"
                        || t.Name == "Schluchhalder"
                        || t.Name == "Bohnenklopferinas"
                        || t.Name == "Dummy Team 2"
                        || t.Name == "Schmetterball"
                        || t.Name == "Musikverein Sasbachried").ToListAsync();
    }

    public async Task<IEnumerable<Team>> GetGruppeD()
    {
        return await _context.Teams
            .Where(t => t.Name == "Rieder Piraten 2"
                        || t.Name == "Maflotho"
                        || t.Name == "The Old Schmetterhänds"
                        || t.Name == "Dummy Team 3"
                        || t.Name == "OlympAllstars").ToListAsync();
    }
    
    public async Task<IEnumerable<Team>> GetGruppeE()
    {
        return await _context.Teams
            .Where(t => t.Name == "Geschwister Bauer"
                        || t.Name == "Team Dobex"
                        || t.Name == "Jungspritzer"
                        || t.Name == "Space Team 2"
                        || t.Name == "Gruschtle").ToListAsync();
    }
    
    public async Task<IEnumerable<Team>> GetGruppeF()
    {
        return await _context.Teams
            .Where(t => t.Name == "Rheingoldstraße"
                        || t.Name == "Kräuterhexen"
                        || t.Name == "SoulEater"
                        || t.Name == "Space Team 1"
                        || t.Name == "Team Havana").ToListAsync();
    }
}