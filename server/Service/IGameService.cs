

public interface IGameService
{
    Task<List<Game>> GetDataAsync();
    Task<Game> GetDataByIdAsync(int id);
    Task<List<Game>> CreateAsync();
    Task<List<Game>> UpdateAsync();
    Task<List<Game>> DeleteAsync();
}
