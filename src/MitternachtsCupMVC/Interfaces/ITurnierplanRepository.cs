using MitternachtsCupMVC.Data;
using MitternachtsCupMVC.Models;

namespace MitternachtsCupMVC.Interfaces;

public interface ITurnierplanRepository
{
    Task<ICollection<GruppenSpielTurnierPlan>> HoleSpieleMitErgebnis();
    Task<ICollection<GruppenSpielTurnierPlan>> HoleSpieleOhneErgebnis();
}