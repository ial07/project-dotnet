using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PlayerClientService : IPlayerClientService
{
    private readonly HttpClient _http;

    public PlayerClientService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Player>> GetDataAsync()
    {
        // GET api/Players
        return await _http.GetFromJsonAsync<List<Player>>("/api/Players");
    }

    public async Task<Player> GetDataByIdAsync(int id)
    {
        // GET api/Players/{id}
        return await _http.GetFromJsonAsync<Player>($"/api/Players/{id}");
    }

    public async Task<Player> CreateAsync(Player player)
    {
        // POST api/Players
        var response = await _http.PostAsJsonAsync("/api/Players", player);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Player>();
    }

    public async Task<Player> UpdateAsync(int id, Player player)
    {
        // PUT api/Players/{id}
        var response = await _http.PutAsJsonAsync($"/api/Players/{id}", player);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Player>();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        // DELETE api/Players/{id}
        var response = await _http.DeleteAsync($"/api/Players/{id}");
        return response.IsSuccessStatusCode;
    }
}
