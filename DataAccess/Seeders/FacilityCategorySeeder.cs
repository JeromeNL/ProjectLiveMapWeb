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
                IconName = "monkeybar",
                HexCode = "#0000FF",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 6,
                Name = "Attractie",
                Description = "Een attractie in het park",
                IconName = "rollercoaster",
                HexCode = "#0000FF",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 7,
                Name = "Sanitaire voorziening",
                Description = "Een sanitaire voorziening zoals een WC of douche",
                IconName = "badge-wc",
                HexCode = "#0000FF",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 8,
                Name = "Accomodatie",
                Description = "Een accomodatie zoals een hotel.",
                IconName = "building-skyscraper",
                HexCode = "#0000FF",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 9,
                Name = "Parkeerplaats",
                Description = "Een parkeerplaats die toegankelijk is voor gasten.",
                IconName = "parking",
                HexCode = "#0000FF",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 10,
                Name = "Afvalcontainers",
                Description = "Verschillende afvalcontainers voor het scheiden van afval",
                IconName = "recycle",
                HexCode = "#0000FF",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 11,
                Name = "AED",
                Description = "Op deze plaats hangt een AED",
                IconName = "heartbeat",
                HexCode = "#0000FF",
                HolidayResortId = 1,
            }
        };
    }
}