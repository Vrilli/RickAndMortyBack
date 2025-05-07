using RickAndMortyDDD.Domain.Entities;

namespace RickAndMortyDDD.Application.Services;

public interface ICharacterService
{
    Task<IEnumerable<Character>> GetAllCharactersAsync();
    Task<Character?> GetCharacterByIdAsync(int id);
}

