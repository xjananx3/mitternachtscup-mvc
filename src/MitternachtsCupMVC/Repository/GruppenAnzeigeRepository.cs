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
    public Task<IEnumerable<Team>> GetGruppeATeams()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Spiel>> GetGruppeASpiele()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Team>> GetGruppeBTeams()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Spiel>> GetGruppeBSpiele()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Team>> GetGruppeCTeams()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Spiel>> GetGruppeCSpiele()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Team>> GetGruppeDTeams()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Spiel>> GetGruppeDSpiele()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Team>> GetGruppeETeams()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Spiel>> GetGruppeESpiele()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Team>> GetGruppeFTeams()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Spiel>> GetGruppeFSpiele()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Team>> GetGruppeGTeams()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Spiel>> GetGruppeGSpiele()
    {
        throw new NotImplementedException();
    }
}