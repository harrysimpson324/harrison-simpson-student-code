using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.DAO
{
    public class CitySqlDao : ICityDao
    {
        private readonly string connectionString;

        public CitySqlDao(string connString)
        {
            connectionString = connString;
        }

        public int GetCityCount()
        {
            int count = 0;

            string sql = "SELECT COUNT(*) as count FROM city;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    count = Convert.ToInt32(reader["count"]);
                }
            }

            return count;
        }

        public int GetMostPopulatedCity()
        {
            int population = 0;

            string sql = "SELECT MAX(population) as population FROM city;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    population = Convert.ToInt32(reader["population"]);
                }
            }

            return population;
        }

        public int GetLeastPopulatedCity()
        {
            int population = 0;

            string sql = "SELECT MIN(population) as population FROM city;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    population = Convert.ToInt32(reader["population"]);
                }
            }

            return population;
        }

        public decimal GetAverageCityArea()
        {
            decimal avgArea = 0.0M;

            string sql = "SELECT AVG(area) as avg_area FROM city;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    avgArea = Convert.ToDecimal(reader["avg_area"]);
                }
            }

            return avgArea;
        }

        public IList<string> GetCityNames()
        {
            List<string> cityNames = new List<string>();

            string sql = "SELECT city_name FROM city ORDER by city_name ASC;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string cityName = Convert.ToString(reader["city_name"]);
                    cityNames.Add(cityName);
                }

            }

            return cityNames;
        }

        public City GetRandomCity()
        {
            City city = null;

            string sql = "SELECT TOP 1 * FROM city ORDER BY NEWID();";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    city = MapRowToCity(reader);
                }

            }

            return city;
        }

        public City GetCityById(int cityId)
        {
            City city = null;

            string sql = "SELECT city_id, city_name, state_abbreviation, population, area FROM city WHERE city_id = @city_id;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@city_id", cityId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    city = MapRowToCity(reader);
                }
            }

            return city;
        }

        public IList<City> GetCitiesByState(string stateAbbreviation)
        {
            IList<City> cities = new List<City>();

            string sql = "SELECT city_id, city_name, state_abbreviation, population, area FROM city WHERE state_abbreviation = @state_abbreviation;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@state_abbreviation", stateAbbreviation);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    City city = MapRowToCity(reader);
                    cities.Add(city);
                }
            }

            return cities;
        }



        private City MapRowToCity(SqlDataReader reader)
        {
            City city = new City();
            city.CityId = Convert.ToInt32(reader["city_id"]);
            city.CityName = Convert.ToString(reader["city_name"]);
            city.StateAbbreviation = Convert.ToString(reader["state_abbreviation"]);
            city.Population = Convert.ToInt32(reader["population"]);
            city.Area = Convert.ToDecimal(reader["area"]);

            return city;
        }
    }
}
