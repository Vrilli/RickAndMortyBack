using RickAndMortyDDD.Domain.Entities;

namespace RickAndMortyDDD.Domain.Repositories;

public interface IEpisodeRepository
{
    Task<IEnumerable<Episode>> GetAllAsync();
    Task<Episode?> GetByIdAsync(int id);
}
