using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPlayerClientService
{
    Task<List<Player>> GetDataAsync();
    Task<Player> GetDataByIdAsync(int id);
    Task<Player> CreateAsync(Player player);
    Task<Player> UpdateAsync(int id, Player player);
    Task<bool> DeleteAsync(int id);
}
