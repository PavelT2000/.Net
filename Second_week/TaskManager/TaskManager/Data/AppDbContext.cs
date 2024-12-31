using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<MyTask> MyTasks { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
}
