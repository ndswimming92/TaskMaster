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
            new User { Id = 2, UserName = "JaneSmith", Password = 5678 },
            new User { Id = 3, UserName = "AliceJohnson", Password = 9012 },
            new User { Id = 4, UserName = "BobBrown", Password = 3456 }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Work" },
            new Category { Id = 2, Name = "Personal" },
            new Category { Id = 3, Name = "Fitness" },
            new Category { Id = 4, Name = "Hobbies" }
        );

        modelBuilder.Entity<TaskMaster.Models.Task>().HasData(
            new TaskMaster.Models.Task { Id = 1, Title = "Complete Report", Description = "Finish the quarterly report", DueDate = DateTime.Now.AddDays(3), Priority = 1, UserId = 1 },
            new TaskMaster.Models.Task { Id = 2, Title = "Buy Groceries", Description = "Milk, Bread, Eggs", DueDate = DateTime.Now.AddDays(1), Priority = 2, UserId = 2 },
            new TaskMaster.Models.Task { Id = 3, Title = "Go to the Gym", Description = "Workout session at the gym", DueDate = DateTime.Now.AddDays(2), Priority = 3, UserId = 3 },
            new TaskMaster.Models.Task { Id = 4, Title = "Read Book", Description = "Read 'The Great Gatsby'", DueDate = DateTime.Now.AddDays(4), Priority = 4, UserId = 4 },
            new TaskMaster.Models.Task { Id = 5, Title = "Prepare Presentation", Description = "Prepare slides for Monday meeting", DueDate = DateTime.Now.AddDays(5), Priority = 1, UserId = 1 },
            new TaskMaster.Models.Task { Id = 6, Title = "Call Mom", Description = "Catch up with mom", DueDate = DateTime.Now.AddDays(6), Priority = 2, UserId = 2 }
        );

        modelBuilder.Entity<TaskCategory>().HasData(
            new TaskCategory { Id = 1, TaskId = 1, CategoryId = 1 },
            new TaskCategory { Id = 2, TaskId = 2, CategoryId = 2 },
            new TaskCategory { Id = 3, TaskId = 3, CategoryId = 3 },
            new TaskCategory { Id = 4, TaskId = 4, CategoryId = 4 },
            new TaskCategory { Id = 5, TaskId = 5, CategoryId = 1 },
            new TaskCategory { Id = 6, TaskId = 6, CategoryId = 2 }
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