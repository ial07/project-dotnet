using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class GameService : IGameService
{
    private readonly AppDbContext _db;

    public GameService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Game>> GetDataAsync()
    {
       // return await _db.Games.ToListAsync();
         return await _db.Games
                    .Include(g => g.Player) // JOIN ke tabel Player
                    .ToListAsync(); 

    }

    public async Task<Game?> GetDataByIdAsync(int id)
    {
        return await _db.Games.FindAsync(id);
    }

    public async Task<Game> CreateAsync(Game games)
    {
        _db.Games.Add(games);
        await _db.SaveChangesAsync();
        return games;
    }

    public async Task<Game?> UpdateAsync(int id, Game games)
    {
        var existingGame = await _db.Games.FindAsync(id);
        if (existingGame == null) return null;

        existingGame.Name = games.Name;
        await _db.SaveChangesAsync();
        return existingGame;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var games = await _db.Games.FindAsync(id);
        if (games == null) return false;

        _db.Games.Remove(games);
        await _db.SaveChangesAsync();
        return true;
    }
}
