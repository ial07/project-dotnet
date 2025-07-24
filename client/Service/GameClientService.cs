using System.Net.Http.Json;

public class GameClientService : IGameClientService
{
    private readonly HttpClient _http;

    public GameClientService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Game>> GetDataAsync()
    {
        return await _http.GetFromJsonAsync<List<Game>>("/api/Game/GetData");   
    }

    public async Task<Game> GetDataByIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<Game>($"/api/Game/GetData/{id}");
    }

    public async Task<Game> CreateAsync(Game games)
    {
        var response = await _http.PostAsJsonAsync("/api/Game", games);
        return await response.Content.ReadFromJsonAsync<Game>();
    }

    public async Task<Game> UpdateAsync(int id, Game game)
    {
        var response = await _http.PutAsJsonAsync($"/api/Game/{id}", game);
        return await response.Content.ReadFromJsonAsync<Game>();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync($"/api/Game/{id}");
        return response.IsSuccessStatusCode;
    }
}
