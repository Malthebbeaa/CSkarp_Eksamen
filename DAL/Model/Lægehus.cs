using System.ComponentModel.DataAnnotations;

namespace DAL.Model;

public class Lægehus
{
    [Key]
    public int Ydernummer  { get; set; }
    public string Navn { get; set; }
    public List<Recept>  Recepter { get; set; } = new List<Recept>();
    
    public Lægehus(){}
}