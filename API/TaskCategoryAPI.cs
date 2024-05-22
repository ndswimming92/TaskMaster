using Microsoft.EntityFrameworkCore;
using TaskMaster.Models;

namespace TaskMaster.API
{
    public static class TaskCategoryAPI
    {
        public static void Map(WebApplication app)
        {

            // Add Category to Task
            app.MapPut("/api/tasks/{taskId}/categories/{categoryId}", (TaskMasterDbContext db, int taskId, int categoryId) =>
            {
                var task = db.Tasks
                             .Include(t => t.TaskCategories)
                             .SingleOrDefault(t => t.Id == taskId);
                var category = db.Categories
                                 .SingleOrDefault(c => c.Id == categoryId);

                if (task == null)
                {
                    return Results.BadRequest("Task not found.");
                }

                if (category == null)
                {
                    return Results.BadRequest("Category not found.");
                }

                try
                {
                    // Check if the relationship already exists
                    if (!task.TaskCategories.Any(tc => tc.CategoryId == categoryId))
                    {
                        var taskCategory = new TaskCategory
                        {
                            TaskId = taskId,
                            CategoryId = categoryId
                        };

                        db.TaskCategories.Add(taskCategory);
                        db.SaveChanges();

                        // Reload the task with its categories to include in the response
                        task = db.Tasks
                                 .Include(t => t.TaskCategories)
                                 .ThenInclude(tc => tc.Category)
                                 .SingleOrDefault(t => t.Id == taskId);
                    }
                    else
                    {
                        return Results.BadRequest("The task already has this category.");
                    }

                    return Results.Ok(task);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest($"An error occurred: {ex.Message}");
                }
            });


        }

    }

}
