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

            // Get Single Category
            app.MapGet("/api/category/{id}", (TaskMasterDbContext db, int id) =>
            {
                var itemID = db.Categories.FirstOrDefault(c => c.Id == id);

                if (itemID == null)
                {
                    return Results.NotFound("Category Not Found.");
                }

                return Results.Ok(itemID);
            });

        }
    }
}
