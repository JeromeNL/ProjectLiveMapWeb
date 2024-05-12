using DataAccess.Models;
using DataAccess.Seeders.Abstract;

namespace DataAccess.Seeders;

public class FacilityCategorySeeder : ISeeder<FacilityCategory>
{
    public List<FacilityCategory> Seed()
    {
        return new List<FacilityCategory>
        {
            // Categories for Efteling
            new()
            {
                Id = 1,
                Name = "Restaurant",
                Description = "Voorzieningen die eten en drinken mogelijk maken",
                IconName = "chef-hat",
                HexCode = "#D70040",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 2,
                Name = "Speeltuin",
                Description = "Voorzieningen die spelen mogelijk maken",
                IconName = "monkeybar",
                HexCode = "#DA70D6",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 3,
                Name = "Attractie",
                Description = "Een attractie in het park",
                IconName = "rollercoaster",
                HexCode = "#40E0D0",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 4,
                Name = "Sanitaire voorziening",
                Description = "Een sanitaire voorziening zoals een WC of douche",
                IconName = "badge-wc",
                HexCode = "#E2725B",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 5,
                Name = "Accomodatie",
                Description = "Een accomodatie zoals een hotel.",
                IconName = "building-skyscraper",
                HexCode = "#BFFF00",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 6,
                Name = "Parkeerplaats",
                Description = "Een parkeerplaats die toegankelijk is voor gasten.",
                IconName = "parking",
                HexCode = "#D3D3D3",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 7,
                Name = "Afvalcontainers",
                Description = "Verschillende afvalcontainers voor het scheiden van afval",
                IconName = "recycle",
                HexCode = "#FFB6C1",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 8,
                Name = "AED",
                Description = "Op deze plaats hangt een AED",
                IconName = "heartbeat",
                HexCode = "#CCCCFF",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 9,
                Name = "Overig",
                Description = "Overige plaatsen zoals ingangen",
                IconName = "map-pin",
                HexCode = "#2E8B57",
                HolidayResortId = 1,
            },
            
            new()
            {
                Id = 10,
                Name = "Sport",
                Description = "Voorzieningen die sport mogelijk maken",
                IconName = "ball-tennis",
                HexCode = "#D70040",
                HolidayResortId = 2,
            },
            
            new()
            {
                Id = 11,
                Name = "Supermarkt",
                Description = "Voorzieningen die boodschappen mogelijk maken",
                IconName = "shopping-cart",
                HexCode = "#50C878",
                HolidayResortId = 2,
            },
            new()
            {
                Id = 12,
                Name = "Zwembad",
                Description = "Voorzieningen die zwemmen mogelijk maken",
                IconName = "swimming",
                HexCode = "#FFBF00",
                HolidayResortId = 2,
            }
        };
    }
}