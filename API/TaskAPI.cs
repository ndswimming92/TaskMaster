using TaskMaster.Models;

namespace TaskMaster.API
{
    public class TaskAPI
    {
        public static void Map(WebApplication app)
        {
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
        }
    }
}
