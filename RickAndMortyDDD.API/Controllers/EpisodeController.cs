using Microsoft.AspNetCore.Mvc;
using RickAndMortyDDD.Application.Services;

namespace RickAndMortyDDD.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EpisodeController : ControllerBase
{
    private readonly IEpisodeService _service;

    public EpisodeController(IEpisodeService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var episodes = await _service.GetAllEpisodesAsync();
        return Ok(episodes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var episode = await _service.GetEpisodeByIdAsync(id);
        if (episode is null) return NotFound();
        return Ok(episode);
    }
}
