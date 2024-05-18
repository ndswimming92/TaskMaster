using Microsoft.EntityFrameworkCore;
using TaskMaster.Models;
using System;


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
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, UserName = "JohnDoe", Password = 1234 },
            new User { Id = 2, UserName = "JaneSmith", Password = 5678 }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Work" },
            new Category { Id = 2, Name = "Personal" }
        );

        modelBuilder.Entity<TaskMaster.Models.Task>().HasData(
            new TaskMaster.Models.Task { Id = 1, Title = "Complete Report", Description = "Finish the quarterly report", DueDate = DateTime.Now.AddDays(3), Priority = 1, UserId = 1 },
            new TaskMaster.Models.Task { Id = 2, Title = "Buy Groceries", Description = "Milk, Bread, Eggs", DueDate = DateTime.Now.AddDays(1), Priority = 2, UserId = 2 }
        );

        modelBuilder.Entity<TaskCategory>().HasData(
            new TaskCategory { Id = 1, TaskId = 1, CategoryId = 1 },
            new TaskCategory { Id = 2, TaskId = 2, CategoryId = 2 }
        );

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