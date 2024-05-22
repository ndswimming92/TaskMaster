using TaskMaster.Models;

namespace TaskMaster.API
{
    public static class UserAPI
    {
        public static void Map(WebApplication app)
        {
            // Create a User
            app.MapPost("api/user", (TaskMasterDbContext db, User users) =>
            {
                db.Users.Add(users);
                db.SaveChanges();
                return Results.Created($"/api/user/{users.Id}", users);

            });

            

        }

    }
}
