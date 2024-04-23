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
                Coordinates =
                    "[{\"lat\":51.65437450244091,\"lng\":5.0508467565706505},{\"lat\":51.64987678408715,\"lng\":5.046164433345783},{\"lat\":51.64865247578396,\"lng\":5.055099508857458}]"
            },
            new()
            {
                Id = 2,
                Name = "Vierwaldstättersee",
                Coordinates =
                    "[{\"lat\":51.65437450244091,\"lng\":5.0508467565706505},{\"lat\":51.64987678408715,\"lng\":5.046164433345783},{\"lat\":51.64865247578396,\"lng\":5.055099508857458}]"
            }
        };
    }
}