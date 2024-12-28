using Microsoft.EntityFrameworkCore;
using TODOLIst;

public class AppDbContext : DbContext
{
    public DbSet<MyTask> Tasks { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
