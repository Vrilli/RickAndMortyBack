using RickAndMortyDDD.Domain.Entities;
using RickAndMortyDDD.Domain.Repositories;


namespace RickAndMortyDDD.Application.Services;

public class EpisodeService : IEpisodeService
{
    private readonly IEpisodeRepository _episodeRepository;
    private readonly ICharacterRepository _characterRepository; // Necesitas esto para traer personajes

    public EpisodeService(IEpisodeRepository episodeRepository, ICharacterRepository characterRepository)
    {
        _episodeRepository = episodeRepository;
        _characterRepository = characterRepository;
    }

    public async Task<IEnumerable<Episode>> GetAllEpisodesAsync()
    {
        var episodes = await _episodeRepository.GetAllAsync();

        foreach (var episode in episodes)
        {
            var firstCharUrl = episode.Characters?.FirstOrDefault();
            if (!string.IsNullOrEmpty(firstCharUrl))
            {
                var charId = ExtractCharacterId(firstCharUrl);
                var character = await _characterRepository.GetByIdAsync(charId);
                episode.FirstCharacter = character;
            }
        }

        return episodes;
    }

    public async Task<Episode?> GetEpisodeByIdAsync(int id)
    {
        var episode = await _episodeRepository.GetByIdAsync(id);

        if (episode != null && episode.Characters?.Any() == true)
        {
            var firstCharUrl = episode.Characters.FirstOrDefault();
            if (!string.IsNullOrEmpty(firstCharUrl))
            {
                var charId = ExtractCharacterId(firstCharUrl);
                var character = await _characterRepository.GetByIdAsync(charId);
                episode.FirstCharacter = character;
            }
        }

        return episode;
    }

    private int ExtractCharacterId(string url)
    {
        var parts = url.Split('/');
        return int.Parse(parts.Last());
    }
}
