using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MobileMapAPI.Endpoints;

public class UserEndpoints
{
    public static void MapUserEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/users", (LiveMapDbContext context) =>
        {
            var users = context.Users.ToList();
            return Results.Ok(users);
        });
        
        app.MapGet("/users/{name}", (string name, LiveMapDbContext context) =>
        {
            var users = context.Users.ToList();
            foreach (User user in users)
            {
                if (user.Name == name)
                {
                    return Results.Ok(user);
                }    
            }

            return Results.NotFound("User not found");
        });
    } 
}