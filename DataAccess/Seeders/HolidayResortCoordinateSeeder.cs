using DataAccess.Models;
using DataAccess.Seeders.Abstract;

namespace DataAccess.Seeders;

public class HolidayResortCoordinateSeeder : ISeeder<HolidayResortCoordinate>
{
    public List<HolidayResortCoordinate> Seed()
    {
        return new List<HolidayResortCoordinate>()
        {
            new()
            {
                Id = 1,
                HolidayResortId = 1,
                Order = 1,
                Longitude = 51.653202521428078,
                Latitude = 5.0413749255922244
            },
            new()
            {
                Id = 2,
                HolidayResortId = 1,
                Order = 2,
                Longitude = 51.653721716281296,
                Latitude = 5.0550985543836768,
            },
            new()
            {
                Id = 3,
                HolidayResortId = 1,
                Order = 3,
                Longitude = 51.64661222380488,
                Latitude = 5.0575641086431933
            },
            new()
            {
                Id = 4,
                HolidayResortId = 1,
                Order = 4,
                Longitude = 51.646425817616468,
                Latitude = 5.0443668045587984
            },
            new()
            {
                Id = 5,
                HolidayResortId = 1,
                Order = 5,
                Longitude = 51.649581304758911,
                Latitude = 5.0386373727005704
            },
            new()
            {
                Id = 6,
                HolidayResortId = 2,
                Order = 1,
                Longitude = 51.653202521428078,
                Latitude = 5.0413749255922244
            },
            new()
            {
                Id = 7,
                HolidayResortId = 2,
                Order = 2,
                Longitude = 51.653721716281296,
                Latitude = 5.0550985543836768,
            },
            new()
            {
                Id = 8,
                HolidayResortId = 2,
                Order = 3,
                Longitude = 51.64661222380488,
                Latitude = 5.0575641086431933
            },
            new()
            {
                Id = 9,
                HolidayResortId = 2,
                Order = 4,
                Longitude = 51.646425817616468,
                Latitude = 5.0443668045587984
            },
            new()
            {
                Id = 10,
                HolidayResortId = 2,
                Order = 5,
                Longitude = 51.649581304758911,
                Latitude = 5.0386373727005704
            }
        };
    }
}