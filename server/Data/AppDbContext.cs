using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.UseMySql("server=localhost;database=videogamesdb_2;user=root;password=;", ServerVersion.AutoDetect("server=localhost;database=videogamesdb_2;user=root;password=;"));

    }

    public DbSet<Game> Games { get; set; }
}