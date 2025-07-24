
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
        var games = await _db.Games.ToListAsync();
        return games;
    }

    public Task<Game> GetDataByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Game>> CreateAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<Game>> DeleteAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<Game>> UpdateAsync()
    {
        throw new NotImplementedException();
    }
}