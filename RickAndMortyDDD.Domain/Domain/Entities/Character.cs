namespace RickAndMortyDDD.Domain.Entities;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Status { get; set; } = default!;
    public string Species { get; set; } = default!;
    public string Gender { get; set; } = default!;
    public string Origin { get; set; } = default!;
    public string Location { get; set; } = default!;
    public string Image { get; set; } = default!;
}
