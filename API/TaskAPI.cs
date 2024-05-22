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

            
        }
    }
}
