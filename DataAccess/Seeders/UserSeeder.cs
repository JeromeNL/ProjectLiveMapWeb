using DataAccess.Models;
using DataAccess.Seeders.Abstract;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Seeders;

public class UserSeeder: ISeeder<ApplicationUser>
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
        };

        foreach (var user in users)
        {
            user.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(user, DefaultPassword);
            user.NormalizedUserName = user.UserName!.ToUpper();
        }

        return users;
    }
}