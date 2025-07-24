using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly IGameService _gameService;

    public GameController(IConfiguration config, IGameService gameService)
    {
        _config = config;
        _gameService = gameService;
    }

    [HttpGet("GetData")]
    public async Task<IActionResult> GetDataAsync()
    {
        var result = await _gameService.GetDataAsync();
        return Ok(result);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetDataById(int id)
    {
        var games = await _gameService.GetDataByIdAsync(id);
        if (games == null)
            return NotFound();

        return Ok(games);
    }

  
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Game games)
    {
        var created = await _gameService.CreateAsync(games);
        return CreatedAtAction(nameof(GetDataById), new { id = created.Id }, created);
    }

 
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Game games)
    {
        var updated = await _gameService.UpdateAsync(id, games);
        if (updated == null)
            return NotFound();

        return Ok(updated);
    }

  
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _gameService.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
