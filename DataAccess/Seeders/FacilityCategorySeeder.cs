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
                HexCode = "#7F3FBF",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 2,
                Name = "Speeltuin",
                Description = "Voorzieningen die spelen mogelijk maken",
                IconName = "monkeybar",
                HexCode = "#FE8B15",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 3,
                Name = "Attractie",
                Description = "Een attractie in het park",
                IconName = "rollercoaster",
                HexCode = "#FFC611",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 4,
                Name = "Sanitaire voorziening",
                Description = "Een sanitaire voorziening zoals een WC of douche",
                IconName = "badge-wc",
                HexCode = "#0047AB",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 5,
                Name = "Accomodatie",
                Description = "Een accomodatie zoals een hotel.",
                IconName = "building-skyscraper",
                HexCode = "#FA4748",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 6,
                Name = "Parkeerplaats",
                Description = "Een parkeerplaats die toegankelijk is voor gasten.",
                IconName = "parking",
                HexCode = "#808080",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 7,
                Name = "Afvalcontainers",
                Description = "Verschillende afvalcontainers voor het scheiden van afval",
                IconName = "recycle",
                HexCode = "#6FAB2C",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 8,
                Name = "AED",
                Description = "Op deze plaats hangt een AED",
                IconName = "heartbeat",
                HexCode = "#8B0000",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 9,
                Name = "Overig",
                Description = "Overige plaatsen zoals ingangen",
                IconName = "map-pin",
                HexCode = "#32CD32",
                HolidayResortId = 1,
            },
            
            new()
            {
                Id = 10,
                Name = "Sport",
                Description = "Voorzieningen die sport mogelijk maken",
                IconName = "ball-tennis",
                HexCode = "#30D5C8",
                HolidayResortId = 1,
            },
            
            new()
            {
                Id = 11,
                Name = "Supermarkt",
                Description = "Voorzieningen die boodschappen mogelijk maken",
                IconName = "shopping-cart",
                HexCode = "#F472B6",
                HolidayResortId = 1,
            },
            new()
            {
                Id = 12,
                Name = "Zwembad",
                Description = "Voorzieningen die zwemmen mogelijk maken",
                IconName = "swimming",
                HexCode = "#027FE8",
                HolidayResortId = 1,
            },
            
            
            
            // For landal
             new()
            {
                Id = 101,
                Name = "Restaurant",
                Description = "Voorzieningen die eten en drinken mogelijk maken",
                IconName = "chef-hat",
                HexCode = "#7F3FBF",
                HolidayResortId = 2,
            },
            new()
            {
                Id = 102,
                Name = "Speeltuin",
                Description = "Voorzieningen die spelen mogelijk maken",
                IconName = "monkeybar",
                HexCode = "#FE8B15",
                HolidayResortId = 2,
            },
            new()
            {
                Id = 103,
                Name = "Attractie",
                Description = "Een attractie in het park",
                IconName = "rollercoaster",
                HexCode = "#FFC611",
                HolidayResortId = 2,
            },
            new()
            {
                Id = 104,
                Name = "Sanitaire voorziening",
                Description = "Een sanitaire voorziening zoals een WC of douche",
                IconName = "badge-wc",
                HexCode = "#0047AB",
                HolidayResortId = 2,
            },
            new()
            {
                Id = 105,
                Name = "Accomodatie",
                Description = "Een accomodatie zoals een hotel.",
                IconName = "building-skyscraper",
                HexCode = "#FA4748",
                HolidayResortId = 2,
            },
            new()
            {
                Id = 106,
                Name = "Parkeerplaats",
                Description = "Een parkeerplaats die toegankelijk is voor gasten.",
                IconName = "parking",
                HexCode = "#808080",
                HolidayResortId = 2,
            },
            new()
            {
                Id = 107,
                Name = "Afvalcontainers",
                Description = "Verschillende afvalcontainers voor het scheiden van afval",
                IconName = "recycle",
                HexCode = "#6FAB2C",
                HolidayResortId = 2,
            },
            new()
            {
                Id = 108,
                Name = "AED",
                Description = "Op deze plaats hangt een AED",
                IconName = "heartbeat",
                HexCode = "#8B0000",
                HolidayResortId = 2,
            },
            new()
            {
                Id = 109,
                Name = "Overig",
                Description = "Overige plaatsen zoals ingangen",
                IconName = "map-pin",
                HexCode = "#32CD32",
                HolidayResortId = 2,
            },
            
            new()
            {
                Id = 110,
                Name = "Sport",
                Description = "Voorzieningen die sport mogelijk maken",
                IconName = "ball-tennis",
                HexCode = "#30D5C8",
                HolidayResortId = 2,
            },
            
            new()
            {
                Id = 111,
                Name = "Supermarkt",
                Description = "Voorzieningen die boodschappen mogelijk maken",
                IconName = "shopping-cart",
                HexCode = "#F472B6",
                HolidayResortId = 2,
            },
            new()
            {
                Id = 112,
                Name = "Zwembad",
                Description = "Voorzieningen die zwemmen mogelijk maken",
                IconName = "swimming",
                HexCode = "#027FE8",
                HolidayResortId = 2,
            }
        };
    }
}