using Microsoft.EntityFrameworkCore;
// using server.Data; // Pastikan namespace AppDbContext sudah sesuai
// using server.Service; // Pastikan namespace GameService dan IGameService sesuai

var builder = WebApplication.CreateBuilder(args);

// Tambahkan policy CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:5090") // alamat Blazor WebAssembly client kamu
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers()
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });


// Tambahkan layanan ke container
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

// Tambahkan dependency injection untuk GameService
builder.Services.AddScoped<IGameService, GameService>();

var app = builder.Build();

// Swagger hanya aktif saat Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Aktifkan CORS di sini, sebelum Authorization dan MapControllers
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
