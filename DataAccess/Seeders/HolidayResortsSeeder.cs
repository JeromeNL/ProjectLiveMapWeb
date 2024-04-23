using DataAccess.Models;
using DataAccess.Seeders.Abstract;

namespace DataAccess.Seeders;

public class HolidayResortsSeeder: ISeeder<HolidayResort>
{
    public List<HolidayResort> Seed()
    {
        return new List<HolidayResort>
        {
            new()
            {
                Id = 1,
                Name = "Efteling",
                NorthEastLatitude = 51.65409301291617,
                NorthEastLongitude = 5.055245412377415,
                SouthWestLatitude = 51.64662722820029,
                SouthWestLongitude = 5.044088892700313
            },
           new()
           {
               Id = 2,
               Name = "Hof van Saksen",
               NorthEastLatitude = 52.970413,
               NorthEastLongitude = 6.680389,
               SouthWestLatitude = 52.960658,
               SouthWestLongitude = 6.672377
           },
           new()
           {
               Id = 3,
               Name = "Vierwaldstättersee",
               NorthEastLatitude = 46.982750, 
               NorthEastLongitude = 8.617061,
               SouthWestLatitude = 46.980330, 
               SouthWestLongitude = 8.613706
           }
        };
    }
}