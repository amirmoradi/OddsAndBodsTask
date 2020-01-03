using System.Collections.Generic;
using System.Linq;
using OddsAndBodsTask.Models;

namespace OddsAndBodsTask.DAL
{
    public class PlanetRepository
    {
        /// <summary>
        /// Getting Planet Item by URL
        /// </summary>
        public static Planet GetPlanet(string url)
        {
            using (var context = new StarWarsContext())
            {
                return context.Planet.FirstOrDefault(x => x.Url == url);
            }
        }

        /// <summary>
        /// Adding new Planet Items
        /// </summary>
        public static void Insert(List<Planet> entities)
        {
            using (var context = new StarWarsContext())
            {
                context.Planet.AddRange(entities);
                context.SaveChanges();
            }
        }
    }
}
