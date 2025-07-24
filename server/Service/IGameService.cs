

public interface IGameService
{
    Task<List<Game>> GetDataAsync();
    Task<Game?> GetDataByIdAsync(int id);     
    Task<Game> CreateAsync(Game games);               
    Task<Game?> UpdateAsync(int id, Game games);       
    Task<bool> DeleteAsync(int id);                   
}
