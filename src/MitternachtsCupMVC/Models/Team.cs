using System.ComponentModel.DataAnnotations;

namespace MitternachtsCupMVC.Models;
public class Team
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    
}