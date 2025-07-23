using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class GameControllerBase : ControllerBase
{
    protected readonly IConfiguration _config;
    protected readonly GameService _gameService;

    protected GameControllerBase(IConfiguration config, GameService gameService)
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
}