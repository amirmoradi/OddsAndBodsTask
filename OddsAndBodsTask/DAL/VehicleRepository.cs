using System.Collections.Generic;
using System.Linq;
using OddsAndBodsTask.Models;

namespace OddsAndBodsTask.DAL
{
    public class VehicleRepository
    {
        public static bool VehicleExist(string url)
        {
            using (var context = new StarWarsContext())
            {
                return context.Vehicle.Any(x => x.Url == url);
            }
        }

        public static Vehicle GetVehicle(string url)
        {
            using (var context = new StarWarsContext())
            {
                return context.Vehicle.FirstOrDefault(x => x.Url == url);
            }
        }
        
        public static void Insert(List<Vehicle> entities)
        {
            using (var context = new StarWarsContext())
            {
                context.Vehicle.AddRange(entities);
                context.SaveChanges();
            }
        }
    }
}
