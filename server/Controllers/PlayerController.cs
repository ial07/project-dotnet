using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly AppDbContext _context;

    public PlayersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
    {
        return await _context.Players.Include(p => p.Games).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Player>> GetPlayer(int id)
    {
        var player = await _context.Players.Include(p => p.Games)
                                           .FirstOrDefaultAsync(p => p.PlayerID == id);
        if (player == null) return NotFound();
        return player;
    }

    [HttpPost]
    public async Task<ActionResult<Player>> CreatePlayer(Player player)
    {
        _context.Players.Add(player);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPlayer), new { id = player.PlayerID }, player);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePlayer(int id, Player player)
    {
        if (id != player.PlayerID) return BadRequest();
        var existing = await _context.Players.Include(p => p.Games).FirstOrDefaultAsync(p => p.PlayerID == id);
        if (existing == null) return NotFound();

        existing.UserName = player.UserName;
        existing.Address = player.Address;
        existing.PhoneNumber = player.PhoneNumber;
        existing.Games = player.Games;

        await _context.SaveChangesAsync();
       return Ok(existing);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlayer(int id)
    {
        var player = await _context.Players.Include(p => p.Games).FirstOrDefaultAsync(p => p.PlayerID == id);
        if (player == null) return NotFound();

        _context.Players.Remove(player);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
