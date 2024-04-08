using DataAccess.Models;
using DataAccess.Seeders.Abstract;

namespace DataAccess.Seeders;

public class UserSeeder: ISeeder<User>
{
    public List<User> Seed()
    {
        return new List<User>
        {
            new()
            {
                Id = 1,
                Name = "Almior"
            },
            new()
            {
                Id = 2,
                Name = "Joram"
            },
            new()
            {
                Id = 3,
                Name = "Thieme"
            },
            new()
            {
                Id = 4,
                Name = "Mauro"
            },
            new()
            {
                Id = 5,
                Name = "Imke"
            },
            new()
            {
                Id = 6,
                Name = "Lamine"
            },
        };
    }
}