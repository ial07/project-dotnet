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
    public Task<List<Game>> CreateAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<Game>> DeleteAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Game> GetDataByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Game>> UpdateAsync()
    {
        throw new NotImplementedException();
    }
}