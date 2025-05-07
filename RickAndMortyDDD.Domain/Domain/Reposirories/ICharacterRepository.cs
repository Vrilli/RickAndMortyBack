using RickAndMortyDDD.Domain.Entities;
using RickAndMortyDDD.Domain.Repositories;


namespace RickAndMortyDDD.Domain.Repositories;

public interface ICharacterRepository
{
    Task<IEnumerable<Character>> GetAllAsync();
    Task<Character?> GetByIdAsync(int id);
}


