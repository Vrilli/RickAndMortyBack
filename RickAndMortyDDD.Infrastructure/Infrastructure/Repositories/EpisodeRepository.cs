using RickAndMortyDDD.Domain.Entities;
using RickAndMortyDDD.Domain.Repositories;
using RickAndMortyDDD.Infrastructure.ExternalApis;

namespace RickAndMortyDDD.Infrastructure.Repositories;

public class EpisodeRepository : IEpisodeRepository
{
    private readonly IRickAndMortyApi _api;

    public EpisodeRepository(IRickAndMortyApi api)
    {
        _api = api;
    }

    public async Task<IEnumerable<Episode>> GetAllAsync()
    {
        var response = await _api.GetAllEpisodesAsync();
        var episodes = new List<Episode>();
        var random = new Random();

        foreach (var e in response.Content.Results)
        {
            Character? randomCharacter = await GetRandomCharacterFromEpisodeAsync(e.Characters, random);

            episodes.Add(new Episode
            {
                Id = e.Id,
                Name = e.Name,
                AirDate = e.Air_Date,
                EpisodeCode = e.Episode,
                Characters = e.Characters,
                FirstCharacter = randomCharacter
            });
        }

        return episodes;
    }

    public async Task<Episode?> GetByIdAsync(int id)
    {
        var e = (await _api.GetEpisodeByIdAsync(id)).Content;
        var random = new Random();
        Character? randomCharacter = await GetRandomCharacterFromEpisodeAsync(e.Characters, random);

        return new Episode
        {
            Id = e.Id,
            Name = e.Name,
            AirDate = e.Air_Date,
            EpisodeCode = e.Episode,
            Characters = e.Characters,
            FirstCharacter = randomCharacter
        };
    }

    private int ExtractCharacterId(string characterUrl)
    {
        var parts = characterUrl.Split('/');
        return int.Parse(parts[^1]);
    }

    private async Task<Character> GetRandomCharacterFromEpisodeAsync(List<string>? characterUrls, Random random)
    {
        if (characterUrls is not null && characterUrls.Any())
        {
            var randomCharacterUrl = characterUrls[random.Next(characterUrls.Count)];
            var characterId = ExtractCharacterId(randomCharacterUrl);
            var characterResponse = await _api.GetCharacterByIdAsync(characterId);

            if (characterResponse.IsSuccessStatusCode && characterResponse.Content is not null)
            {
                var c = characterResponse.Content;

                return new Character
                {
                    Id = c.Id,
                    Name = string.IsNullOrWhiteSpace(c.Name) ? "Sin personaje" : c.Name,
                    Image = string.IsNullOrWhiteSpace(c.Image) ? "/images/default-image.jpg" : c.Image
                };
            }
        }

        // Si no hay personajes o la API falla.
        return new Character
        {
            Id = 0,
            Name = "Sin personaje",
            Image = "https://static.wikia.nocookie.net/wiki-de-rick-morty/images/c/c7/Tricia_Lange.png/revision/latest/smart/width/250/height/250?cb=20200714021315&path-prefix=es"
        };
    }
}
