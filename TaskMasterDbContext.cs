using Microsoft.EntityFrameworkCore;
using TaskMaster.Models;


public class TaskMasterDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<TaskMaster.Models.Task> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<TaskCategory> TaskCategories { get; set; }

    public TaskMasterDbContext(DbContextOptions<TaskMasterDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskCategory>()
            .HasKey(tc => tc.Id);

        modelBuilder.Entity<TaskCategory>()
            .HasOne(tc => tc.Task)
            .WithMany(t => t.TaskCategories)
            .HasForeignKey(tc => tc.TaskId);

        modelBuilder.Entity<TaskCategory>()
            .HasOne(tc => tc.Category)
            .WithMany(c => c.TaskCategories)
            .HasForeignKey(tc => tc.CategoryId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Tasks)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId);
    }
}