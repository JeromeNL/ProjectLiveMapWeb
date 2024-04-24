using DataAccess.Models;
using DataAccess.Seeders.Abstract;

namespace DataAccess.Seeders;

public class FacilitySeeder: ISeeder<Facility>
{
    public List<Facility> Seed()
    {
        return new List<Facility>
        {
            new()
            {
                Id = 1,
                Name = "Restaurant de Kom",
                Description = "Restaurant de Kom is een gezellig restaurant",
                CategoryId = 1,
                Latitude = 51.64797080730413,
                Longitude = 5.046858473421019,
                HolidayResortId = 1,
            },
            new()
            {
                Id = 2,
                Name = "Zwemmeer",
                Description =
                    "In dit meer kun je in de zomer heerlijk zwemmen. Ook is er een strandje waar je kunt zonnen.",
                CategoryId = 3,
                Latitude = 51.64722313562921,
                Longitude = 5.05165372379847,
                HolidayResortId = 1,
            },
            new()
            {
                Id = 3,
                Name = "Speeltuin",
                Description = "De speeltuin is een leuke plek voor kinderen om te spelen.",
                CategoryId = 1,
                Latitude = 51.651976894252684,
                Longitude = 5.053454583354487,
                HolidayResortId = 1,
            }
        };
    }
}