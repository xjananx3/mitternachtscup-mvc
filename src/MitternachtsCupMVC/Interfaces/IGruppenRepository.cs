using System.Collections;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC.Interfaces;

public interface IGruppenRepository
{
    Task<IEnumerable<Team>> GetGruppeA();
    Task<IEnumerable<Team>> GetGruppeB();
    Task<IEnumerable<Team>> GetGruppeC();
    Task<IEnumerable<Team>> GetGruppeD();
    
}