namespace RickAndMortyDDD.Domain.Entities;

public class Episode
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string AirDate { get; set; } = default!;
    public string EpisodeCode { get; set; } = default!;
    public List<string> Characters { get; set; } = new List<string>();
    public Character? FirstCharacter { get; set; }
    public string? FirstCharacterImage { get; set; }
    public string? FirstCharacterName { get; set; }
}




