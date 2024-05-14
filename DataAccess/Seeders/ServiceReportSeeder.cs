using DataAccess.Models;
using DataAccess.Seeders.Abstract;

namespace DataAccess.Seeders;

public class ServiceReportSeeder : ISeeder<ServiceReport>
{
    private readonly Random _random = new();

    public List<ServiceReport> Seed()
    {
        return new List<ServiceReport>
        {
            new()
            {
                Id = 1,
                Title = "Ruit gebroken",
                Description = "Er is hier een ruit gebroken ",
                CreatedAt = DateTime.Now,
                FacilityId = 1,
                ServiceReportCategoryId = 1,
                UserId = GetRandomId(1, 6),
                HolidayResortId = 1
            },
            new()
            {
                Id = 2,
                Title = "Verstopte WC",
                Description = "De WC op de heren wc naast de lobby is verstopt.",
                CreatedAt = DateTime.Now,
                FacilityId = 5,
                ServiceReportCategoryId = 3,
                UserId = GetRandomId(1, 6),
                HolidayResortId = 1
            },
            new()
            {
                Id = 3,
                Title = "Vloerbedekking kapot",
                Description = "In de gang van kamer 203 is de vloerbedekking kapot en ligt los.",
                CreatedAt = DateTime.Now,
                FacilityId = 5,
                ServiceReportCategoryId = 1,
                UserId = GetRandomId(1, 6),
                HolidayResortId = 1
            },
            new()
            {
                Id = 4,
                Title = "Overgegeven in de rij",
                Description = "Iemand heeft overgegeven in de wachtrij, dus de wachtrij is niet helemaal fris",
                CreatedAt = DateTime.Now,
                FacilityId = 11,
                ServiceReportCategoryId = 3,
                UserId = GetRandomId(1, 6),
                HolidayResortId = 1
            },
            new()
            {
                Id = 5,
                Title = "Bord kapot",
                Description = "Het eerste bord in de wachtrij toont geen wachttijd meer",
                CreatedAt = DateTime.Now,
                FacilityId = 11,
                ServiceReportCategoryId = 1,
                UserId = GetRandomId(1, 6),
                HolidayResortId = 1
            },
            new()
            {
                Id = 6,
                Title = "Stickers plakken",
                Description = "Er zijn hier een paar kerels overal stickers aan het plakken op allerlei voorwerpen",
                CreatedAt = DateTime.Now,
                FacilityId = 11,
                ServiceReportCategoryId = 2,
                UserId = GetRandomId(1, 6),
                HolidayResortId = 1
            },
            
            new()
            {
                Id = 7,
                Title = "Prullenbak vol",
                Description = "De prullenbak naast de receptie zit vol. Er ligt ook al afval naast",
                CreatedAt = DateTime.Now,
                FacilityId = 12,
                ServiceReportCategoryId = 3,
                UserId = GetRandomId(1, 6),
                HolidayResortId = 2
            },
            new()
            {
                Id = 8,
                Title = "Stinkt naar Chloor",
                Description = "Het stinkt enorm naar Chloor in de kleedkamer",
                CreatedAt = DateTime.Now,
                FacilityId = 13,
                ServiceReportCategoryId = 3,
                UserId = GetRandomId(1, 6),
                HolidayResortId = 2
            },
            new()
            {
                Id = 9,
                Title = "Wasmachine kapot",
                Description = "Wasmachine nummer 15 doet het niet meer. En ik krijg mijn kleren er niet meer uit..",
                CreatedAt = DateTime.Now,
                FacilityId = 15,
                ServiceReportCategoryId = 4,
                UserId = GetRandomId(1, 6),
                HolidayResortId = 2
            },
            new()
            {
                Id = 10,
                Title = "Kabel is gebroken",
                Description = "De kabel van de kabelbaan is gebroken",
                CreatedAt = DateTime.Now,
                FacilityId = 18,
                ServiceReportCategoryId = 1,
                UserId = GetRandomId(1, 6),
                HolidayResortId = 2
            },
            new()
            {
                Id = 11,
                Title = "AED geeft foutmelding",
                Description = "De AED geeft een storing aan. Hopelijk kan dit zsm opgelost worden, voordat 'ie nodig is.",
                CreatedAt = DateTime.Now,
                FacilityId = 20,
                ServiceReportCategoryId = 6,
                UserId = GetRandomId(1, 6),
                HolidayResortId = 2
            },
        };
        
}

    // Helper method to generate a random integer within a specified range
    private int GetRandomId(int min, int max)
    {
        return _random.Next(min, max + 1);
    }
}