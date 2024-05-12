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
                Name = "Ingang",
                Description = "De ingang van het park",
                CategoryId = 24,
                Latitude = 51.64951171793103,
                Longitude = 5.043722178305341,
                HolidayResortId = 1,
            },
            new()
            {
                Id = 2,
                Name = "Parkeerplaats",
                Description = "De parkeerplaats voor bezoekers",
                CategoryId = 21,
                Latitude = 51.651905368320875,
                Longitude = 5.043013398820558,
                HolidayResortId = 1,
            },
            new()
            {
                Id = 3,
                Name = "Ezeltje Strek je",
                Description = "Tafeltje Dek Je, Ezeltje Strek je",
                CategoryId = 18,
                Latitude = 51.65049725846648,
                Longitude = 5.045352776939619,
                HolidayResortId = 1,
            },
            new()
            {
                Id = 4,
                Name = "Toiletten - Station de Oost",
                Description = "De toiletten bij Station de Oost",
                CategoryId = 19,
                Latitude = 51.648253943429594,
                Longitude = 5.054205329439788,
                HolidayResortId = 1,
            },
            new()
            {
                Id = 5,
                Name = "Efteling Hotel",
                Description = "Het hotel van de Efteling",
                CategoryId = 20,
                Latitude = 51.6533095116168,
                Longitude = 5.0545935396996065,
                HolidayResortId = 1,
            },
            new()
            {
                Id = 6,
                Name = "Parkeerplaats - Efteling Hotel",
                Description = "Parkeerplaats voor gasten van het Efteling Hotel",
                CategoryId = 21,
                Latitude = 51.65283044936814,
                Longitude = 5.054573377884308,
                HolidayResortId = 1,
            },
            new()
            {
                Id = 7,
                Name = "Efteling Museum",
                Description = "Het Museum",
                CategoryId = 18,
                Latitude = 51.65229430498627,
                Longitude = 5.0501061313485796,
                HolidayResortId = 1,
            },
            new()
            {
                Id = 8,
                Name = "Gondoletta",
                Description = "De mogelijkheid om te in het park te varen.",
                CategoryId = 18,
                Latitude = 51.65045027352614,
                Longitude = 5.051228169656645,
                HolidayResortId = 1,
            },
            new()
            {
                Id = 9,
                Name = "Baron 1898",
                Description = "Misschien wel de beste achtbaan van het park!",
                CategoryId = 18,
                Latitude = 51.648240487276276,
                Longitude = 5.0476227628708035,
                HolidayResortId = 1,
            },
            new()
            {
                Id = 10,
                Name = "Symbolica",
                Description = "Mooie attractie",
                CategoryId = 18,
                Latitude = 51.65047698865882,
                Longitude = 5.049463370712903,
                HolidayResortId = 1,
            },
            new()
            {
                Id = 11,
                Name = "Joris en de draak",
                Description = "Een houten achtbaan",
                CategoryId = 18,
                Latitude = 51.646819390364065,
                Longitude = 5.052419063365133,
                HolidayResortId = 1,
            }
        };
    }
}