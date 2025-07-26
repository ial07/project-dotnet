using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5128")
});

// Daftarkan GameService
builder.Services.AddScoped<IGameClientService, GameClientService>();
builder.Services.AddScoped<IPlayerClientService, PlayerClientService>();




await builder.Build().RunAsync();
