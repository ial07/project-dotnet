
using Microsoft.EntityFrameworkCore;

public class GameService : IGameService
{
    private readonly AppDbContext _db;

    public GameService(AppDbContext db)
    {
        _db = db;
    }
    public async Task<List<Game>> GetDataAsync()
    {
        var games = await _db.Game.ToListAsync();
        return games;
    }
}