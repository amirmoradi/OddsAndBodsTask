using System.Collections.Generic;
using System.Linq;
using OddsAndBodsTask.Models;

namespace OddsAndBodsTask.DAL
{
    public class SpeciesRepository
    {
        /// <summary>
        /// Getting Species by URL
        /// </summary>
        
        public static Species GetSpecies(string url)
        {
            using (var context = new StarWarsContext())
            {
                return context.Species.FirstOrDefault(x => x.Url == url);
            }
        }
        
        /// <summary>
        /// Adding new Species items
        /// </summary>
        public static void Insert(List<Species> entities)
        {
            using (var context = new StarWarsContext())
            {
                context.Species.AddRange(entities);
                context.SaveChanges();
            }
        }
    }
}
