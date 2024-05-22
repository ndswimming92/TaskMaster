using TaskMaster.Models;

namespace TaskMaster.API
{
    public class TaskAPI
    {
        public static void Map(WebApplication app)
        {

            // Create a Task
            app.MapPost("/api/task", (TaskMasterDbContext db, TaskMaster.Models.Task newTask) =>
            {
                db.Tasks.Add(newTask);
                db.SaveChanges();
                return Results.Created($"/api/task/{newTask.Id}", newTask);
            });

            // Get All Tasks
            app.MapGet("/api/tasks", (TaskMasterDbContext db) =>
            {
                return db.Tasks.ToList();
            });

            // Get Tasks by Id
            app.MapGet("/api/task/{id}", (TaskMasterDbContext db, int id) =>
            {
                var task = db.Tasks.FirstOrDefault(task => task.Id == id);

                if (task == null)
                {
                    return Results.NotFound("Task was not found.");
                }

                return Results.Ok(task);
            });

            // Update a Task
            app.MapPut("/api/task/{id}", (TaskMasterDbContext db, int id, TaskMaster.Models.Task task) =>
            {
                TaskMaster.Models.Task taskToUpdate = db.Tasks.SingleOrDefault(task => task.Id == id);

                if (taskToUpdate == null)
                {
                    return Results.NotFound("Task was not found.");
                }

                taskToUpdate.Id = task.Id;
                taskToUpdate.Title = task.Title;
                taskToUpdate.Description = task.Description;
                taskToUpdate.DueDate = task.DueDate;
                taskToUpdate.Priority = task.Priority;
                taskToUpdate.UserId = task.UserId;
              
                db.SaveChanges();
                return Results.NoContent();
            });
        }
    }
}
