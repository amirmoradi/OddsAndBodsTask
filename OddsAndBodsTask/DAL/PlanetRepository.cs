using System.Collections.Generic;
using System.Linq;
using OddsAndBodsTask.Models;

namespace OddsAndBodsTask.DAL
{
    public class PlanetRepository
    {
        public static bool PlanetExist(string url)
        {
            using (var context = new StarWarsContext())
            {
                return context.Planet.Any(x => x.Url == url);
            }
        }
        public static Planet GetPlanet(string url)
        {
            using (var context = new StarWarsContext())
            {
                return context.Planet.FirstOrDefault(x => x.Url == url);
            }
        }

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
