using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using OddsAndBodsTask.Classes;
using OddsAndBodsTask.DAL;
using OddsAndBodsTask.Helpers;
using OddsAndBodsTask.Models;
using OddsAndBodsTask.Models.ResponseModels;

namespace OddsAndBodsTask
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            var config = configuration.GetSection("MyConfig").Get<MyConfig>();

            LogHelper.SubmitLog("Task: Build a C# command line application which retrieves a subset of data exposed by the Star Wars API ( https://swapi.co ) and inserts it into a SQL Server database and then exits. ", LogType.Comment);

            LogHelper.SubmitLog("Please hit a key to proceed......", LogType.Warning);
            Console.ReadKey();

            //Before start adding items to database we have to make sure the database is clean
            ClearDatabase();

            //Start the process -- Getting data from API, build models and add them to database
            ProcessItems(config.SWAPIUrl);

            Environment.Exit(0);
        }

        /// <summary>
        /// Clearing data from database
        /// </summary>
        private static void ClearDatabase()
        {
            LogHelper.SubmitLog("Cleaning database", LogType.Comment);
            DataAccessRepository.ClearData();
            LogHelper.SubmitLog("All data cleaned from database", LogType.Info);

            LogHelper.SubmitLog("...........................................", LogType.Comment);
        }

        /// <summary>
        /// Process Items
        /// </summary>
        private static void ProcessItems(string baseUrl)
        {
            try
            {
                //Getting data from API
                LogHelper.SubmitLog("Getting Peoples", LogType.Comment);
                var people = GetAllPeople(baseUrl);
                LogHelper.SubmitLog($"{people.Count} peoples retrieved", LogType.Info);

                LogHelper.SubmitLog("Getting Films", LogType.Comment);
                var films = GetFilms(baseUrl);
                LogHelper.SubmitLog($"{films.Count} films retrieved", LogType.Info);

                LogHelper.SubmitLog("Getting Planets", LogType.Comment);
                var planets = GetPlanets(baseUrl);
                LogHelper.SubmitLog($"{planets.Count} planets retrieved", LogType.Info);

                LogHelper.SubmitLog("Getting Species", LogType.Comment);
                var species = GetSpecies(baseUrl);
                LogHelper.SubmitLog($"{species.Count} species retrieved", LogType.Info);

                LogHelper.SubmitLog("Getting StarShips", LogType.Comment);
                var starShips = GetStarships(baseUrl);
                LogHelper.SubmitLog($"{starShips.Count} starships retrieved", LogType.Info);

                LogHelper.SubmitLog("Getting Vehicles", LogType.Comment);
                var vehicles = GetVehicles(baseUrl);
                LogHelper.SubmitLog($"{vehicles.Count} vehicles retrieved", LogType.Info);


                LogHelper.SubmitLog("...........................................", LogType.Comment);
                
                //Adding objects to Database
                LogHelper.SubmitLog("Processing Films...", LogType.Comment);
                var filmsToAdd = ModelFactory.GenerateNewFilms(films);
                FilmRepository.Insert(filmsToAdd);
                LogHelper.SubmitLog("Done!", LogType.Info);

                LogHelper.SubmitLog("Processing Planets...", LogType.Comment);
                var planetsToAdd = ModelFactory.GenerateNewPlanets(planets);
                PlanetRepository.Insert(planetsToAdd);
                LogHelper.SubmitLog($"Done!", LogType.Info);

                LogHelper.SubmitLog("Processing Vehicles...", LogType.Comment);
                var vehiclesToAdd = ModelFactory.GenerateNewVehicles(vehicles);
                VehicleRepository.Insert(vehiclesToAdd);
                LogHelper.SubmitLog("Done!", LogType.Info);

                LogHelper.SubmitLog("Processing Starships...", LogType.Comment);
                var starshipsToAdd = ModelFactory.GenerateNewStarShips(starShips);
                StarshipRepository.Insert(starshipsToAdd);
                LogHelper.SubmitLog("Done!", LogType.Info);

                LogHelper.SubmitLog("Processing Species...", LogType.Comment);
                var speciesToAdd = ModelFactory.GenerateNewSpecies(species);
                SpeciesRepository.Insert(speciesToAdd);
                LogHelper.SubmitLog("Done!", LogType.Info);

                LogHelper.SubmitLog("Processing People...", LogType.Comment);
                var peopleToAdd = ModelFactory.GenerateNewPeople(people);
                PeopleRepository.Insert(peopleToAdd);
                LogHelper.SubmitLog("Done!", LogType.Info);
            }
            catch (Exception exp)
            {
                LogHelper.SubmitLog(exp.Message, LogType.Error);
            }
        }

        /// <summary>
        /// Get Vehicles from SWAPI
        /// </summary>
        private static List<VehicleResponseItemModel> GetVehicles(string baseUrl)
        {
            var vehicleItems = new List<VehicleResponseItemModel>();
            var vehicles = HttpRequestsHelper.ExecuteGetRequest<VehiclesResponse>(baseUrl.Replace("{{::Placeholder::}}", "vehicles")) as VehiclesResponse;
            if (vehicles != null)
            {
                vehicleItems.AddRange(vehicles.results);

                //If more than 10 items exists, API provides data in different pages. This loop is to get all available pages for the object
                if (vehicles.count > 10)
                {
                    var url = vehicles.next;
                    var pages = vehicles.count / 10 + 1;

                    for (int i = 1; i < pages; i++)
                    {
                        vehicles = HttpRequestsHelper.ExecuteGetRequest<VehiclesResponse>(url) as VehiclesResponse;
                        url = vehicles.next;
                        vehicleItems.AddRange(vehicles.results);
                        if (string.IsNullOrEmpty(vehicles.next))
                            break;
                    }
                }
            }

            return vehicleItems;
        }

        /// <summary>
        /// Get StarShips from SWAPI
        /// </summary>
        private static List<StarshipResponseItemModel> GetStarships(string baseUrl)
        {
            var starshipItems = new List<StarshipResponseItemModel>();
            var starShips = HttpRequestsHelper.ExecuteGetRequest<StarShipResponse>(baseUrl.Replace("{{::Placeholder::}}", "starships")) as StarShipResponse;
            if (starShips != null)
            {
                starshipItems.AddRange(starShips.results);

                //If more than 10 items exists, API provides data in different pages. This loop is to get all available pages for the object
                if (starShips.count > 10)
                {
                    var url = starShips.next;
                    var pages = starShips.count / 10 + 1;

                    for (int i = 1; i < pages; i++)
                    {
                        starShips = HttpRequestsHelper.ExecuteGetRequest<StarShipResponse>(url) as StarShipResponse;
                        url = starShips.next;
                        starshipItems.AddRange(starShips.results);
                        if (string.IsNullOrEmpty(starShips.next))
                            break;
                    }
                }
            }

            return starshipItems;
        }

        /// <summary>
        /// Get Species from SWAPI
        /// </summary>
        private static List<SpeciesResponseItemModel> GetSpecies(string baseUrl)
        {
            var speciesItems = new List<SpeciesResponseItemModel>();
            var species = HttpRequestsHelper.ExecuteGetRequest<SpeciesResponse>(baseUrl.Replace("{{::Placeholder::}}", "species")) as SpeciesResponse;
            if (species != null)
            {
                speciesItems.AddRange(species.results);

                //If more than 10 items exists, API provides data in different pages. This loop is to get all available pages for the object
                if (species.count > 10)
                {
                    var url = species.next;
                    var pages = species.count / 10 + 1;

                    for (int i = 1; i < pages; i++)
                    {
                        species = HttpRequestsHelper.ExecuteGetRequest<SpeciesResponse>(url) as SpeciesResponse;
                        url = species.next;
                        speciesItems.AddRange(species.results);
                        if (string.IsNullOrEmpty(species.next))
                            break;
                    }
                }
            }

            return speciesItems;
        }

        /// <summary>
        /// Get Planets from SWAPI
        /// </summary>
        private static List<PlanetResponseItemModel> GetPlanets(string baseUrl)
        {
            var planetItems = new List<PlanetResponseItemModel>();
            var planets = HttpRequestsHelper.ExecuteGetRequest<PlanetsResponse>(baseUrl.Replace("{{::Placeholder::}}", "planets")) as PlanetsResponse;
            if (planets != null)
            {
                planetItems.AddRange(planets.results);

                //If more than 10 items exists, API provides data in different pages. This loop is to get all available pages for the object
                if (planets.count > 10)
                {
                    var url = planets.next;
                    var pages = planets.count / 10 + 1;

                    for (int i = 1; i < pages; i++)
                    {
                        planets = HttpRequestsHelper.ExecuteGetRequest<PlanetsResponse>(url) as PlanetsResponse;
                        url = planets.next;
                        planetItems.AddRange(planets.results);
                        if (string.IsNullOrEmpty(planets.next))
                            break;
                    }
                }
            }

            return planetItems;
        }

        /// <summary>
        /// Get Films from SWAPI
        /// </summary>
        private static List<FilmResponseItemModel> GetFilms(string baseUrl)
        {
            var firmItems = new List<FilmResponseItemModel>();
            var films = HttpRequestsHelper.ExecuteGetRequest<FilmsResponse>(baseUrl.Replace("{{::Placeholder::}}", "films")) as FilmsResponse;
            if (films != null)
            {
                firmItems.AddRange(films.results);

                //If more than 10 items exists, API provides data in different pages. This loop is to get all available pages for the object
                if (films.count > 10)
                {
                    var url = films.next;
                    var pages = films.count / 10 + 1;

                    for (int i = 1; i < pages; i++)
                    {
                        films = HttpRequestsHelper.ExecuteGetRequest<FilmsResponse>(url) as FilmsResponse;
                        url = films.next;
                        firmItems.AddRange(films.results);
                        if (string.IsNullOrEmpty(films.next))
                            break;
                    }
                }
            }

            return firmItems;
        }

        /// <summary>
        /// Get People from SWAPI
        /// </summary>
        private static List<PeopleResponseItemModel> GetAllPeople(string baseUrl)
        {
            var peopleItems = new List<PeopleResponseItemModel>();

            var people =
                HttpRequestsHelper.ExecuteGetRequest<PeopleResponse>(baseUrl.Replace("{{::Placeholder::}}", "people")) as PeopleResponse;

            if (people != null)
            {
                peopleItems.AddRange(people.results);

                //If more than 10 items exists, API provides data in different pages. This loop is to get all available pages for the object
                if (people.count > 10)
                {
                    var url = people.next;
                    var pages = people.count / 10 + 1;

                    for (int i = 1; i < pages; i++)
                    {
                        people = HttpRequestsHelper.ExecuteGetRequest<PeopleResponse>(url) as PeopleResponse;
                        url = people.next;
                        peopleItems.AddRange(people.results);
                        if (string.IsNullOrEmpty(people.next))
                            break;
                    }
                }
            }

            return peopleItems;
        }
    }
}
