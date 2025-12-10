namespace DTO;

public class OrdinationDTO
{
    public Guid OrdinationId { get; set; }
    public string Lægemiddel { get; set; }
    public string Dosis { get; set; }
    public int AntalUdleveringer { get; set; }
    public int AntalForetagneUdleveringer { get; set; }

    public override string ToString()
    {
        return $"{Lægemiddel} -  {Dosis} - {AntalUdleveringer}";
    }
}