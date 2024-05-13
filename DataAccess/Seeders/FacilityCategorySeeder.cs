using DataAccess.Models;
using DataAccess.Seeders.Abstract;

namespace DataAccess.Seeders;

public class FacilityCategorySeeder : ISeeder<FacilityCategory>
{
    public List<FacilityCategory> Seed()
    {
        return new List<FacilityCategory>
        {
            new()
            {
                Id = 1,
                Name = "Restaurant",
                Description = "Voorzieningen die eten en drinken mogelijk maken",
                IconName = "chef-hat",
                HexCode = "#0000FF",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 2,
                Name = "Sport",
                Description = "Voorzieningen die sport mogelijk maken",
                IconName = "ball-tennis",
                HexCode = "#0000FF",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 3,
                Name = "Supermarkt",
                Description = "Voorzieningen die boodschappen mogelijk maken",
                IconName = "shopping-cart",
                HexCode = "#0000FF",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 4,
                Name = "Zwembad",
                Description = "Voorzieningen die zwemmen mogelijk maken",
                IconName = "swimming",
                HexCode = "#0000FF",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 5,
                Name = "Speeltuin",
                Description = "Voorzieningen die spelen mogelijk maken",
                IconName = "sandbox",
                HexCode = "#0000FF",
                HolidayResortId = 1,
            }
        };
    }
}