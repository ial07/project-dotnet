using Microsoft.EntityFrameworkCore;
//using server.Data; // Ganti dengan namespace AppDbContext kamu
//using server.Service; // Ganti dengan namespace GameService dan IGameService kamu

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Koneksi ke MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(10, 4, 32))
    )
);

// ✅ Tambahkan DI untuk GameService
builder.Services.AddScoped<IGameService, GameService>();

var app = builder.Build();

// Swagger hanya aktif saat Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
