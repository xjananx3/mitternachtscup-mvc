using System.Collections;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC.Interfaces;

public interface IGruppenRepository
{
    Task<IEnumerable<Team>> GetGruppeA();
    Task<ICollection<GruppenSpiel>> ErstelleSpieleGruppeA();
    Task<IEnumerable<Team>> GetGruppeB();
    Task<ICollection<GruppenSpiel>> ErstelleSpieleGruppeB();
    Task<IEnumerable<Team>> GetGruppeC();
    Task<ICollection<GruppenSpiel>> ErstelleSpieleGruppeC();
    Task<IEnumerable<Team>> GetGruppeD();
    Task<ICollection<GruppenSpiel>> ErstelleSpieleGruppeD();
    Task<IEnumerable<Team>> GetGruppeE();
    Task<ICollection<GruppenSpiel>> ErstelleSpieleGruppeE();
    Task<IEnumerable<Team>> GetGruppeF();
    Task<ICollection<GruppenSpiel>> ErstelleSpieleGruppeF();
    Task<IEnumerable<Team>> GetGruppeG();
    Task<ICollection<GruppenSpiel>> ErstelleSpieleGruppeG();
}