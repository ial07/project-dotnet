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
}
