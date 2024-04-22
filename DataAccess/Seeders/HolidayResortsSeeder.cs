using DataAccess.Models;
using DataAccess.Seeders.Abstract;

namespace DataAccess.Seeders;

public class HolidayResortsSeeder : ISeeder<HolidayResort>
{
    public List<HolidayResort> Seed()
    {
        return new List<HolidayResort>
        {
            new()
            {
                Id = 1,
                Name = "Hof van Saksen",
            },
            new()
            {
                Id = 2,
                Name = "Vierwaldstättersee",
            }
        };
    }
}