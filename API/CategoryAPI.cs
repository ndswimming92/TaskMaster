using TaskMaster.Models;

namespace TaskMaster.API
{
    public class CategoryAPI
    {
        public static void Map(WebApplication app)
        {

            // Create a Category
            app.MapPost("/api/category", (TaskMasterDbContext db, Category newCategory) =>
            {
                db.Categories.Add(newCategory);
                db.SaveChanges();
                return Results.Created($"/api/category/{newCategory.Id}", newCategory);
            });

            // Get All Categories
            app.MapGet("/api/categories", (TaskMasterDbContext db) =>
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

            // Update a Category
            app.MapPut("/api/category/{id}", (TaskMasterDbContext db, int id, Category category) =>
            {
                Category categoryToUpdate = db.Categories.SingleOrDefault(category => category.Id == id);

                if (categoryToUpdate == null)
                {
                    return Results.NotFound("Category was not found.");
                }

                categoryToUpdate.Id = category.Id;
                categoryToUpdate.Name = category.Name;

                               
                db.SaveChanges();
                return Results.Ok(category);
            });

        }
    }
}
