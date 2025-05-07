using RickAndMortyDDD.Domain.Repositories;
using RickAndMortyDDD.Domain.Entities;

namespace RickAndMortyDDD.Application.Services;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _characterRepository;

    public CharacterService(ICharacterRepository characterRepository)
    {
        _characterRepository = characterRepository;
    }

    public async Task<IEnumerable<Character>> GetAllCharactersAsync()
    {
        return await _characterRepository.GetAllAsync();
    }

    public async Task<Character?> GetCharacterByIdAsync(int id)
    {
        return await _characterRepository.GetByIdAsync(id);
    }
}
