using Microsoft.EntityFrameworkCore;
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

            // Get User by Id

            app.MapGet("api/user/{id}", (TaskMasterDbContext db, int id) =>
            {
                var userDetails = db.Users
                .FirstOrDefault(users => users.Id == id);

                if (userDetails == null)
                {
                    return Results.NotFound("User not found. Please select a valid ID.");
                }
                return Results.Ok(userDetails);
            });

            // Delete a User

            app.MapDelete("api/user/{id}", (TaskMasterDbContext db, int id) =>
            {
                var userToDelete = db.Users.Include(u => u.Tasks).FirstOrDefault(user => user.Id == id);
                if (userToDelete == null)
                {
                    return Results.NotFound("No User found with that Id.");
                }

                db.Users.Remove(userToDelete);
                db.SaveChanges();
                return Results.Ok(db.Users);
            });
        }

    }
}
