using Movies.DAO;
using Movies.Models;
using System;
using System.Collections.Generic;

namespace Movies
{
    public class MoviesCLI
    {

        private static readonly string MAIN_MENU_OPTION_COLLECTIONS = "Collections";
        private static readonly string MAIN_MENU_OPTION_GENRES = "Genres";
        private static readonly string MAIN_MENU_OPTION_MOVIES = "Movies";
        private static readonly string MAIN_MENU_OPTION_PERSONS = "Persons";
        private static readonly string MAIN_MENU_OPTION_EXIT = "Exit";
        private static readonly string[] MAIN_MENU_OPTIONS = new string[] {
            MAIN_MENU_OPTION_COLLECTIONS, MAIN_MENU_OPTION_GENRES, MAIN_MENU_OPTION_MOVIES,
            MAIN_MENU_OPTION_PERSONS, MAIN_MENU_OPTION_EXIT
        };

        private static readonly string MENU_OPTION_RETURN_TO_MAIN = "Return to main menu";

        private static readonly string COLL_MENU_OPTION_ALL_COLLECTIONS = "Get all Collections";
        private static readonly string COLL_MENU_OPTION_COLLECTION_BY_ID = "Get Collection by ID";
        private static readonly string COLL_MENU_OPTION_COLLECTIONS_BY_NAME_WILDCARD = "Get Collections by name with wildcard";
        private static readonly string COLL_MENU_OPTION_COLLECTIONS_BY_NAME_EXACT = "Get Collections by exact name";
        private static readonly string[] COLL_MENU_OPTIONS = new string[] {
            COLL_MENU_OPTION_ALL_COLLECTIONS,
            COLL_MENU_OPTION_COLLECTION_BY_ID,
            COLL_MENU_OPTION_COLLECTIONS_BY_NAME_WILDCARD,
            COLL_MENU_OPTION_COLLECTIONS_BY_NAME_EXACT,
            MENU_OPTION_RETURN_TO_MAIN
        };

        private static readonly string GENR_MENU_OPTION_ALL_GENRES = "Get all Genres";
        private static readonly string GENR_MENU_OPTION_GENRE_BY_ID = "Get Genre by ID";
        private static readonly string GENR_MENU_OPTION_GENRES_BY_NAME_WILDCARD = "Get Genres by name with wildcard";
        private static readonly string GENR_MENU_OPTION_GENRES_BY_NAME_EXACT = "Get Genres by exact name";
        private static readonly string[] GENR_MENU_OPTIONS = new string[] {
            GENR_MENU_OPTION_ALL_GENRES,
            GENR_MENU_OPTION_GENRE_BY_ID,
            GENR_MENU_OPTION_GENRES_BY_NAME_WILDCARD,
            GENR_MENU_OPTION_GENRES_BY_NAME_EXACT,
            MENU_OPTION_RETURN_TO_MAIN
        };

        private static readonly string MOVI_MENU_OPTION_ALL_MOVIES = "Get all Movies";
        private static readonly string MOVI_MENU_OPTION_MOVIE_BY_ID = "Get Movie by ID";
        private static readonly string MOVI_MENU_OPTION_MOVIES_BY_TITLE_WILDCARD = "Get Movies by name with wildcard";
        private static readonly string MOVI_MENU_OPTION_MOVIES_BY_TITLE_EXACT = "Get Movies by exact name";
        private static readonly string MOVI_MENU_OPTION_MOVIES_BY_DIRECTOR_NAME_BETWEEN_YEARS =
            "Get Movies by Director Name between Years";
        private static readonly string[] MOVI_MENU_OPTIONS = new string[] {
            MOVI_MENU_OPTION_ALL_MOVIES,
            MOVI_MENU_OPTION_MOVIE_BY_ID,
            MOVI_MENU_OPTION_MOVIES_BY_TITLE_WILDCARD,
            MOVI_MENU_OPTION_MOVIES_BY_TITLE_EXACT,
            MOVI_MENU_OPTION_MOVIES_BY_DIRECTOR_NAME_BETWEEN_YEARS,
            MENU_OPTION_RETURN_TO_MAIN
        };

        private static readonly string PERSON_MENU_OPTION_ALL_PERSONS = "Get all Persons";
        private static readonly string PERSON_MENU_OPTION_PERSON_BY_ID = "Get Person by ID";
        private static readonly string PERSON_MENU_OPTION_PERSONS_BY_NAME_WILDCARD = "Get Persons by name with wildcard";
        private static readonly string PERSON_MENU_OPTION_PERSONS_BY_NAME_EXACT = "Get Persons by exact name";
        private static readonly string PERSON_MENU_OPTION_PERSONS_BY_COLLECTION_NAME = "Get Persons By Collection name";
        private static readonly string[] PERSON_MENU_OPTIONS = new string[] {
            PERSON_MENU_OPTION_ALL_PERSONS,
            PERSON_MENU_OPTION_PERSON_BY_ID,
            PERSON_MENU_OPTION_PERSONS_BY_NAME_WILDCARD,
            PERSON_MENU_OPTION_PERSONS_BY_NAME_EXACT,
            PERSON_MENU_OPTION_PERSONS_BY_COLLECTION_NAME,
            MENU_OPTION_RETURN_TO_MAIN
        };

        private readonly ICollectionDao collectionDao;
        private readonly IGenreDao genreDao;
        private readonly IMovieDao movieDao;
        private readonly IPersonDao personDao;

        public MoviesCLI(ICollectionDao collectionDao, IGenreDao genreDao, IMovieDao movieDao, IPersonDao personDao)
        {
            this.collectionDao = collectionDao;
            this.genreDao = genreDao;
            this.movieDao = movieDao;
            this.personDao = personDao;
        }

        public void Run()
        {
            DisplayBanner();

            bool running = true;
            while (running)
            {
                PrintHeading("Main Menu");
                string choice = (string)CLIHelper.GetChoiceFromOptions(MAIN_MENU_OPTIONS);
                if (choice == MAIN_MENU_OPTION_COLLECTIONS)
                {
                    HandleCollections();
                }
                else if (choice == MAIN_MENU_OPTION_GENRES)
                {
                    HandleGenres();
                }
                else if (choice == MAIN_MENU_OPTION_MOVIES)
                {
                    HandleMovies();
                }
                else if (choice == MAIN_MENU_OPTION_PERSONS)
                {
                    HandlePersons();
                }
                else if (choice == MAIN_MENU_OPTION_EXIT)
                {
                    running = false;
                }
            }
        }



        private void HandleCollections()
        {
            while (true)
            {
                PrintHeading("Departments");
                string choice = (string)CLIHelper.GetChoiceFromOptions(COLL_MENU_OPTIONS);
                if (choice == COLL_MENU_OPTION_ALL_COLLECTIONS)
                {
                    HandleGetCollections();
                }
                else if (choice == COLL_MENU_OPTION_COLLECTION_BY_ID)
                {
                    HandleGetCollectionByID();
                }
                else if (choice == COLL_MENU_OPTION_COLLECTIONS_BY_NAME_WILDCARD)
                {
                    HandleGetCollectionByNameWildcard();
                }
                else if (choice == COLL_MENU_OPTION_COLLECTIONS_BY_NAME_EXACT)
                {
                    HandleGetCollectionByNameExact();
                }
                else if (choice == MENU_OPTION_RETURN_TO_MAIN)
                {
                    break;
                }
            }
        }

        private void HandleGetCollections()
        {
            PrintHeading("Get Collections");
            List<Collection> collections = collectionDao.GetCollections();
            ListCollections(collections);
        }

        private void HandleGetCollectionByID()
        {
            PrintHeading("Get Collection by ID");
            int collectionID = Convert.ToInt32(GetUserInput("Enter Collection ID"));

            Collection collection = collectionDao.GetCollectionById(collectionID);
            if (collection != null)
            {
                Console.WriteLine(collection);
            }
            else
            {
                Console.WriteLine("\n*** No results ***");
            }
        }

        private void HandleGetCollectionByNameWildcard()
        {
            PrintHeading("Get Collection by Name (wildcard)");
            string collectionName = GetUserInput("Enter Collection Name");
            
            List<Collection> collections = collectionDao.GetCollectionsByName(collectionName, true);
            ListCollections(collections);
        }

        private void HandleGetCollectionByNameExact()
        {
            PrintHeading("Get Collection by Name (exact)");
            string collectionName = GetUserInput("Enter Collection Name");

            List<Collection> collections = collectionDao.GetCollectionsByName(collectionName, false);
            ListCollections(collections);
        }

        private void ListCollections(List<Collection> collections)
        {
            Console.WriteLine();
            Console.WriteLine("Collection count: " + collections.Count);
            int limit = Math.Min(collections.Count, 10);
            if (limit > 0)
            {
                for (int i = 0; i < limit; i++)
                {
                    Collection collection = collections[i];
                    Console.WriteLine(collection);
                }
            }
            else
            {
                Console.WriteLine("\n*** No results ***");
            }
        }

        private void HandleGenres()
        {
            while (true)
            {
                PrintHeading("Genres");
                string choice = (string)CLIHelper.GetChoiceFromOptions(GENR_MENU_OPTIONS);
                if (choice == GENR_MENU_OPTION_ALL_GENRES)
                {
                    HandleGetGenres();
                }
                else if (choice == GENR_MENU_OPTION_GENRE_BY_ID)
                {
                    HandleGetGenreByID();
                }
                else if (choice == GENR_MENU_OPTION_GENRES_BY_NAME_WILDCARD)
                {
                    HandleGetGenreByNameWildcard();
                }
                else if (choice == GENR_MENU_OPTION_GENRES_BY_NAME_EXACT)
                {
                    HandleGetGenreByNameExact();
                }
                else if (choice == MENU_OPTION_RETURN_TO_MAIN)
                {
                    break;
                }
            }
        }

        private void HandleGetGenres()
        {
            PrintHeading("Get Genres");
            List<Genre> genres = genreDao.GetGenres();
            ListGenres(genres);
        }

        private void HandleGetGenreByID()
        {
            PrintHeading("Get Genre by ID");
            int genreID = Convert.ToInt32(GetUserInput("Enter Genre ID"));
            Genre genre = genreDao.GetGenreById(genreID);
            if (genre != null)
            {
                Console.WriteLine(genre);
            }
            else
            {
                Console.WriteLine("\n*** No results ***");
            }
        }

        private void HandleGetGenreByNameWildcard()
        {
            PrintHeading("Get Genre by Name (wildcard)");
            string genreName = GetUserInput("Enter Genre Name");
            List<Genre> genres = genreDao.GetGenresByName(genreName, true);
            ListGenres(genres);
        }

        private void HandleGetGenreByNameExact()
        {
            PrintHeading("Get Genre by Name (exact)");
            string genreName = GetUserInput("Enter Genre Name");
            List<Genre> genres = genreDao.GetGenresByName(genreName, false);
            ListGenres(genres);
        }

        private void ListGenres(List<Genre> genres)
        {
            Console.WriteLine();
            Console.WriteLine("Genre count: " + genres.Count);
            int limit = Math.Min(genres.Count, 10);
            if (limit > 0)
            {
                for (int i = 0; i < limit; i++)
                {
                    Genre genre = genres[i];
                    Console.WriteLine(genre);
                }
            }
            else
            {
                Console.WriteLine("\n*** No results ***");
            }
        }

        private void HandleMovies()
        {
            while (true)
            {
                PrintHeading("Movies");
                string choice = (string)CLIHelper.GetChoiceFromOptions(MOVI_MENU_OPTIONS);
                if (choice == MOVI_MENU_OPTION_ALL_MOVIES)
                {
                    HandleGetMovies();
                }
                else if (choice == MOVI_MENU_OPTION_MOVIE_BY_ID)
                {
                    HandleGetMovieByID();
                }
                else if (choice == MOVI_MENU_OPTION_MOVIES_BY_TITLE_WILDCARD)
                {
                    HandleGetMovieByTitleWildcard();
                }
                else if (choice == MOVI_MENU_OPTION_MOVIES_BY_TITLE_EXACT)
                {
                    HandleGetMovieByTitleExact();
                }
                else if (choice == MOVI_MENU_OPTION_MOVIES_BY_DIRECTOR_NAME_BETWEEN_YEARS)
                {
                    HandleGetMovieByDirectorNameBetweenYears();
                }
                else if (choice == MENU_OPTION_RETURN_TO_MAIN)
                {
                    break;
                }
            }
        }

        private void HandleGetMovies()
        {
            PrintHeading("Get Movies");
            List<Movie> movies = movieDao.GetMovies();
            ListMovies(movies);
        }

        private void HandleGetMovieByID()
        {
            PrintHeading("Get Movie by ID");
            int movieID = Convert.ToInt32(GetUserInput("Enter Movie ID"));
            Movie movie = movieDao.GetMovieById(movieID);
            if (movie != null)
            {
                Console.WriteLine(movie);
            }
            else
            {
                Console.WriteLine("\n*** No results ***");
            }
        }

        private void HandleGetMovieByTitleWildcard()
        {
            PrintHeading("Get Movie by Title (wildcard)");
            string movieTitle = GetUserInput("Enter Movie Title");
            List<Movie> movies = movieDao.GetMoviesByTitle(movieTitle, true);
            ListMovies(movies);
        }

        private void HandleGetMovieByTitleExact()
        {
            PrintHeading("Get Movie by Title (exact)");
            string movieTitle = GetUserInput("Enter Movie Title");
            List<Movie> movies = movieDao.GetMoviesByTitle(movieTitle, false);
            ListMovies(movies);
        }

        private void HandleGetMovieByDirectorNameBetweenYears()
        {
            PrintHeading("Get Movie by Director Name between Years");
            string directorName = GetUserInput("Enter Director Name");
            int beginYear = Convert.ToInt32(GetUserInput("Enter begin year"));
            int endYear = Convert.ToInt32(GetUserInput("Enter end year"));
            bool wildcard = GetUserInput("Use wildcard (t/f)?").ToLower() == "t";
            List<Movie> movies = movieDao.GetMoviesByDirectorNameAndBetweenYears(directorName, beginYear, endYear, wildcard);
            ListMovies(movies);
        }

        private void ListMovies(List<Movie> movies)
        {
            Console.WriteLine();
            Console.WriteLine("Movie count: " + movies.Count);
            int limit = Math.Min(movies.Count, 10);
            if (limit > 0)
            {
                for (int i = 0; i < limit; i++)
                {
                    Movie movie = movies[i];
                    Console.WriteLine(movie);
                }
            }
            else
            {
                Console.WriteLine("\n*** No results ***");
            }
        }

        private void HandlePersons()
        {
            while (true)
            {
                PrintHeading("Persons");
                string choice = (string)CLIHelper.GetChoiceFromOptions(PERSON_MENU_OPTIONS);
                if (choice == PERSON_MENU_OPTION_ALL_PERSONS)
                {
                    HandleGetPersons();
                }
                else if (choice == PERSON_MENU_OPTION_PERSON_BY_ID)
                {
                    HandleGetPersonByID();
                }
                else if (choice == PERSON_MENU_OPTION_PERSONS_BY_NAME_WILDCARD)
                {
                    HandleGetPersonByNameWildcard();
                }
                else if (choice == PERSON_MENU_OPTION_PERSONS_BY_NAME_EXACT)
                {
                    HandleGetPersonByNameExact();
                }
                else if (choice == PERSON_MENU_OPTION_PERSONS_BY_COLLECTION_NAME)
                {
                    HandleGetPersonByCollectionName();
                }
                else if (choice == MENU_OPTION_RETURN_TO_MAIN)
                {
                    break;
                }
            }
        }

        private void HandleGetPersons()
        {
            PrintHeading("Get Persons");
            List<Person> persons = personDao.GetPersons();
            listPersons(persons);
        }

        private void HandleGetPersonByID()
        {
            PrintHeading("Get Person by ID");
            int personID = Convert.ToInt32(GetUserInput("Enter Person ID"));
            Person person = personDao.GetPersonById(personID);
            if (person != null)
            {
                Console.WriteLine(person);
            }
            else
            {
                Console.WriteLine("\n*** No results ***");
            }
        }

        private void HandleGetPersonByNameWildcard()
        {
            PrintHeading("Get Person by Name (wildcard)");
            string personName = GetUserInput("Enter Person Name");
            List<Person> persons = personDao.GetPersonsByName(personName, true);
            listPersons(persons);
        }

        private void HandleGetPersonByNameExact()
        {
            PrintHeading("Get Person by Name (exact)");
            string personName = GetUserInput("Enter Person Name");
            List<Person> persons = personDao.GetPersonsByName(personName, false);
            listPersons(persons);
        }

        private void HandleGetPersonByCollectionName()
        {
            PrintHeading("Get Person by Collection Name");
            string personName = GetUserInput("Enter Collection Name");
            bool wildcard = GetUserInput("Use wildcard (t/f)?").ToLower() == ("t");
            List<Person> persons = personDao.GetPersonsByCollectionName(personName, wildcard);
            listPersons(persons);
        }

        private void listPersons(List<Person> persons)
        {
            Console.WriteLine();
            Console.WriteLine("Person count: " + persons.Count);
            int limit = Math.Min(persons.Count, 10);
            if (limit > 0)
            {
                for (int i = 0; i < limit; i++)
                {
                    Person person = persons[i];
                    Console.WriteLine(person);
                }
            }
            else
            {
                Console.WriteLine("\n*** No results ***");
            }
        }

        private void PrintHeading(string headingText)
        {
            Console.WriteLine("\n" + headingText);
            for (int i = 0; i < headingText.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        private string GetUserInput(string prompt)
        {
            Console.Write(prompt + " >>> ");
            return Console.ReadLine();
        }

        private void DisplayBanner()
        {
            Console.WriteLine();
            Console.WriteLine(@" ______             _               _____   ______  ");
            Console.WriteLine(@"|  ___ \           (_)             (____ \ (____  \ ");
            Console.WriteLine(@"| | _ | | ___ _   _ _  ____  ___    _   \ \ ____)  )");
            Console.WriteLine(@"| || || |/ _ \ | | | |/ _  )/___)  | |   | |  __  ( ");
            Console.WriteLine(@"| || || | |_| \ V /| ( (/ /|___ |  | |__/ /| |__)  )");
            Console.WriteLine(@"|_||_||_|\___/ \_/ |_|\____|___/   |_____/ |______/ ");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
