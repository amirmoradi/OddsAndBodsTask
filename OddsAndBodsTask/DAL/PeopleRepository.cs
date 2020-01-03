using System.Collections.Generic;
using System.Linq;
using OddsAndBodsTask.Models;

namespace OddsAndBodsTask.DAL
{
    public class PeopleRepository
    {
        /// <summary>
        /// Getting People by URL
        /// </summary>
        public static People GetPeople(string url)
        {
            using (var context = new StarWarsContext())
            {
                return context.People.FirstOrDefault(x => x.Url == url);
            }
        }

        /// <summary>
        /// Adding new People Items
        /// </summary>
        public static void Insert(List<People> entities)
        {
            using (var context = new StarWarsContext())
            {
                context.People.AddRange(entities);
                context.SaveChanges();
            }
        }
    }
}
