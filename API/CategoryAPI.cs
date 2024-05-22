using TaskMaster.Models;

namespace TaskMaster.API
{
    public class CategoryAPI
    {
        public static void Map(WebApplication app)
        {  
            // Get All Categories
            app.MapGet("/api/category", (TaskMasterDbContext db) =>
            {
                return db.Categories.ToList();
            });

            // Get Single Category by Id
            app.MapGet("/api/category/{id}", (TaskMasterDbContext db, int id) =>
            {
                var categoryId = db.Categories.FirstOrDefault(c => c.Id == id);

                if (categoryId == null)
                {
                    return Results.NotFound("Category Not Found.");
                }

                return Results.Ok(categoryId);
            });

        }
    }
}
