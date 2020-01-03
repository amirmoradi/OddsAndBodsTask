using System.Collections.Generic;
using System.Linq;
using OddsAndBodsTask.Models;

namespace OddsAndBodsTask.DAL
{
    public class FilmRepository
    {
        /// <summary>
        /// Getting Film item by URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Film GetFilm(string url)
        {
            using (var context = new StarWarsContext())
            {
                return context.Film.FirstOrDefault(x => x.Url == url);
            }
        }

        /// <summary>
        /// Adding new Film Items
        /// </summary>
        /// <param name="entities"></param>
        public static void Insert(List<Film> entities)
        {
            using (var context = new StarWarsContext())
            {
                context.Film.AddRange(entities);
                context.SaveChanges();
            }
        }
    }
}
