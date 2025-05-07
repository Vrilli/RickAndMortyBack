using Microsoft.AspNetCore.Mvc;
using RickAndMortyDDD.Application.Services;

namespace RickAndMortyDDD.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService _service;

    public CharacterController(ICharacterService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var characters = await _service.GetAllCharactersAsync();
        return Ok(characters);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var character = await _service.GetCharacterByIdAsync(id);
        if (character is null) return NotFound();
        return Ok(character);
    }
}
