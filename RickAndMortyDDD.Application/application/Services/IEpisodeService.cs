using RickAndMortyDDD.Domain.Entities;

namespace RickAndMortyDDD.Application.Services;

public interface IEpisodeService
{
    Task<IEnumerable<Episode>> GetAllEpisodesAsync();
    Task<Episode?> GetEpisodeByIdAsync(int id);
}
