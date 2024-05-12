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
                CategoryId = 9,
                Latitude = 51.64951171793103,
                Longitude = 5.043722178305341,
                HolidayResortId = 1,
            },
            new()
            {
                Id = 2,
                Name = "Parkeerplaats",
                Description = "De parkeerplaats voor bezoekers",
                CategoryId = 6,
                Latitude = 51.651905368320875,
                Longitude = 5.043013398820558,
                HolidayResortId = 1,
            },
            new()
            {
                Id = 3,
                Name = "Ezeltje Strek je",
                Description = "Tafeltje Dek Je, Ezeltje Strek je",
                CategoryId = 3,
                Latitude = 51.65049725846648,
                Longitude = 5.045352776939619,
                HolidayResortId = 1,
            },
            new()
            {
                Id = 4,
                Name = "Toiletten - Station de Oost",
                Description = "De toiletten bij Station de Oost",
                CategoryId = 4,
                Latitude = 51.648253943429594,
                Longitude = 5.054205329439788,
                HolidayResortId = 1,
            },
            new()
            {
                Id = 5,
                Name = "Efteling Hotel",
                Description = "Het hotel van de Efteling",
                CategoryId = 5,
                Latitude = 51.6533095116168,
                Longitude = 5.0545935396996065,
                HolidayResortId = 1,
            },
            new()
            {
                Id = 6,
                Name = "Parkeerplaats - Efteling Hotel",
                Description = "Parkeerplaats voor gasten van het Efteling Hotel",
                CategoryId = 6,
                Latitude = 51.65283044936814,
                Longitude = 5.054573377884308,
                HolidayResortId = 1,
            },
            new()
            {
                Id = 7,
                Name = "Efteling Museum",
                Description = "Het Museum",
                CategoryId = 3,
                Latitude = 51.65229430498627,
                Longitude = 5.0501061313485796,
                HolidayResortId = 1,
            },
            new()
            {
                Id = 8,
                Name = "Gondoletta",
                Description = "De mogelijkheid om te in het park te varen.",
                CategoryId = 3,
                Latitude = 51.65045027352614,
                Longitude = 5.051228169656645,
                HolidayResortId = 1,
            },
            new()
            {
                Id = 9,
                Name = "Baron 1898",
                Description = "Misschien wel de beste achtbaan van het park!",
                CategoryId = 3,
                Latitude = 51.648240487276276,
                Longitude = 5.0476227628708035,
                HolidayResortId = 1,
            },
            new()
            {
                Id = 10,
                Name = "Symbolica",
                Description = "Mooie attractie",
                CategoryId = 3,
                Latitude = 51.65047698865882,
                Longitude = 5.049463370712903,
                HolidayResortId = 1,
            },
            new()
            {
                Id = 11,
                Name = "Joris en de draak",
                Description = "Een houten achtbaan",
                CategoryId = 3,
                Latitude = 51.646819390364065,
                Longitude = 5.052419063365133,
                HolidayResortId = 1,
            },
            
            // Landal
            new()
            {
                Id = 12,
                Name = "Receptie",
                Description = "De receptie van het park",
                CategoryId = 9,
                Latitude = 52.38048275910889,
                Longitude = 6.414194405078889,
                HolidayResortId = 2,
            },
            new()
            {
                Id = 13,
                Name = "Zwembad",
                Description = "Het binnenzwembad",
                CategoryId = 12,
                Latitude = 52.38043061527697,
                Longitude = 6.414730846881867,
                HolidayResortId = 2,
            },
            new()
            {
                Id = 14,
                Name = "Speelweide",
                Description = "Hier kunnen kinderen spelen",
                CategoryId = 2,
                Latitude = 52.382148987068575,
                Longitude = 6.413357555866242,
                HolidayResortId = 2,
            },
            new()
            {
                Id = 15,
                Name = "Wasserette",
                Description = "Was hier je kleren",
                CategoryId = 4,
                Latitude = 52.380194582141655,
                Longitude = 6.414264142513275,
                HolidayResortId = 2,
            },
            new()
            {
                Id = 16,
                Name = "Sportveld",
                Description = "Veld om te te sporten",
                CategoryId = 10,
                Latitude = 52.38250262898549,
                Longitude = 6.4134326577186584,
                HolidayResortId = 2,
            },
            new()
            {
                Id = 17,
                Name = "Afvalcontainers",
                Description = "Containers voor het afval",
                CategoryId = 7,
                Latitude = 52.380283110598135,
                Longitude = 6.413861811161042,
                HolidayResortId = 2,
            },
            new()
            {
                Id = 18,
                Name = "Kabelbaan",
                Description = "De kabelbaan van het park",
                CategoryId = 3,
                Latitude = 52.38126814155448,
                Longitude = 6.412896215915681,
                HolidayResortId = 2,
            },
            new()
            {
                Id = 19,
                Name = "Parkeerplaats",
                Description = "De centrale parkeerplaats",
                CategoryId = 6,
                Latitude = 52.38062680569677,
                Longitude = 6.413765251636506,
                HolidayResortId = 2,
            },
            new()
            {
                Id = 20,
                Name = "AED",
                Description = "Hier hangt een AED",
                CategoryId = 8,
                Latitude = 52.38040758189134,
                Longitude = 6.414274871349336,
                HolidayResortId = 2,
            },
            new()
            {
                Id = 21,
                Name = "Laadpalen",
                Description = "Laadpalen voor elektrische auto's",
                CategoryId = 6,
                Latitude = 52.38080364427554,
                Longitude = 6.414054930210114,
                HolidayResortId = 2,
            }
        };
    }
}