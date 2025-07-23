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
        optionsBuilder
          .UseSqlServer(_configuration.GetConnectionString("defaultConnection"));
    }

    public DbSet<Game> Game { get; set; }
}