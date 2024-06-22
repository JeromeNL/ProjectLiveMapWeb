using DataAccess.Models;
using DataAccess.Seeders.Abstract;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Seeders;

public class UserSeeder : ISeeder<ApplicationUser>
{
    private const string DefaultPassword = "livemap";

    public List<ApplicationUser> Seed()
    {
        var users = new List<ApplicationUser>
        {
            new()
            {
                UserName = "Almior",
            },
            new()
            {
                UserName = "Joram"
            },
            new()
            {
                UserName = "Thieme"
            },
            new()
            {
                UserName = "Mauro"
            },
            new()
            {
                UserName = "Imke"
            },
            new()
            {
                UserName = "Lamine"
            },
            new()
            {
                Id = "56de71e8-894f-4377-ac90-cdfad7e2d267",
                UserName = "SuperAdmin"
            },
            new()
            {
                UserName = "iODigital"
            },
            new()
            {
                UserName = "ResortAdmin",
                HolidayResortId = 1,
            },
            new()
            {
                UserName = "ResortEmployee",
                HolidayResortId = 1,
            },
            new()
            {
                UserName = "Visitor"
            }
        };

        foreach (var user in users)
        {
            user.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(user, DefaultPassword);
            user.NormalizedUserName = user.UserName!.ToUpper();
        }

        return users;
    }
}