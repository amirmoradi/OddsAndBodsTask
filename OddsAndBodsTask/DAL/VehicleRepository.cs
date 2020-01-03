using System.Collections.Generic;
using System.Linq;
using OddsAndBodsTask.Models;

namespace OddsAndBodsTask.DAL
{
    public class VehicleRepository
    {
        /// <summary>
        /// Getting Vehicle by URL
        /// </summary>
        public static Vehicle GetVehicle(string url)
        {
            using (var context = new StarWarsContext())
            {
                return context.Vehicle.FirstOrDefault(x => x.Url == url);
            }
        }

        /// <summary>
        /// Adding Vehicle items
        /// </summary>
        /// <param name="entities"></param>
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
