using DataAccess.Models;
using DataAccess.Seeders.Abstract;

namespace DataAccess.Seeders;

public class UserSeeder: ISeeder<ApplicationUser>
{
    public List<ApplicationUser> Seed()
    {
        return new List<ApplicationUser>
        {
            new()
            {
                UserName = "Almior"
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
    }
}