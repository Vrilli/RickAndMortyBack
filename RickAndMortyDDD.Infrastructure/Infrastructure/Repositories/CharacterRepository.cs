using RickAndMortyDDD.Domain.Repositories;
using RickAndMortyDDD.Domain.Entities;
using RickAndMortyDDD.Infrastructure.ExternalApis;

public class CharacterRepository : ICharacterRepository
{
    private readonly IRickAndMortyApi _api;

    public CharacterRepository(IRickAndMortyApi api)
    {
        _api = api;
    }

    public async Task<IEnumerable<Character>> GetAllAsync()
    {
        var response = await _api.GetAllCharactersAsync();
        return response.Content.Results.Select(c => new Character
        {
            Id = c.Id,
            Name = c.Name,
            Status = c.Status,
            Species = c.Species,
            Gender = c.Gender,
            Origin = c.Origin.Name,
            Location = c.Location.Name,
            Image = c.Image
        });
    }

    public async Task<Character?> GetByIdAsync(int id)
    {
        var response = await _api.GetCharacterByIdAsync(id);
        var c = response.Content;
        return new Character
        {
            Id = c.Id,
            Name = c.Name,
            Status = c.Status,
            Species = c.Species,
            Gender = c.Gender,
            Origin = c.Origin.Name,
            Location = c.Location.Name,
            Image = c.Image
        };
    }
}
