using System.Collections.Generic;
using System.Linq;
using OddsAndBodsTask.Models;

namespace OddsAndBodsTask.DAL
{
    public class StarshipRepository
    {
        /// <summary>
        /// Getting StarShip by URL
        /// </summary>
        public static StarShip GetStarShip(string url)
        {
            using (var context = new StarWarsContext())
            {
                return context.StarShip.FirstOrDefault(x => x.Url == url);
            }
        }
        
        /// <summary>
        /// Adding new Starship items
        /// </summary>
        public static void Insert(List<StarShip> entities)
        {
            using (var context = new StarWarsContext())
            {
                context.StarShip.AddRange(entities);
                context.SaveChanges();
            }
        }
    }
}
