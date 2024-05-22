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

            // Update a User API

            app.MapPut("api/user/{id}", (TaskMasterDbContext db, int id, User users) =>
            {
                DateTime modifyDate = DateTime.Now;
                User updateUser = db.Users.SingleOrDefault(users => users.Id == id);
                if (updateUser == null)
                {
                    return Results.NotFound("User not found");
                }
                updateUser.Id = users.Id;
                updateUser.UserName = users.UserName;
                updateUser.Password = users.Password;
                
                db.SaveChanges();
                return Results.Ok(users);
            });

        }

    }
}
