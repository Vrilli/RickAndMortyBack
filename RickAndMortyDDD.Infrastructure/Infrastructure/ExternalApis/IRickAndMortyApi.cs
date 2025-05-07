using Refit;

namespace RickAndMortyDDD.Infrastructure.ExternalApis;

public interface IRickAndMortyApi
{
    [Get("/character")]
    Task<ApiResponse<CharacterApiResponse>> GetAllCharactersAsync();

    [Get("/character/{id}")]
    Task<ApiResponse<CharacterApiSingleResponse>> GetCharacterByIdAsync(int id);
    [Get("/episode")]
    Task<ApiResponse<EpisodeApiResponse>> GetAllEpisodesAsync();

    [Get("/episode/{id}")]
    Task<ApiResponse<EpisodeDto>> GetEpisodeByIdAsync(int id);
}


public class CharacterApiResponse
{
    public Info Info { get; set; } = default!;
    public List<CharacterDto> Results { get; set; } = new();
}

public class CharacterApiSingleResponse : CharacterDto { }

public class Info
{
    public int Count { get; set; }
    public int Pages { get; set; }
}

public class CharacterDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Status { get; set; } = default!;
    public string Species { get; set; } = default!;
    public string Gender { get; set; } = default!;
    public Origin Origin { get; set; } = default!;
    public Location Location { get; set; } = default!;
    public string Image { get; set; } = default!;
}

public class Origin
{
    public string Name { get; set; } = default!;
}

public class Location
{
    public string Name { get; set; } = default!;
}

public class EpisodeApiResponse
{
    public Info Info { get; set; } = default!;
    public List<EpisodeDto> Results { get; set; } = new();
}

public class EpisodeDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Air_Date { get; set; } = default!;
    public string Episode { get; set; } = default!;
    public List<string>? Characters { get; set; } = default!;
    public CharacterDto? FirstCharacter { get; set; }
}
