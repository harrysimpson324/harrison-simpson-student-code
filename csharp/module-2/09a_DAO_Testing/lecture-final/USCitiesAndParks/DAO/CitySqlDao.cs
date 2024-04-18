using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using USCitiesAndParks.Exceptions;
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

        public City GetCityById(int cityId)
        {
            City city = null;

            string sql = "SELECT city_id, city_name, state_abbreviation, population, area FROM city WHERE city_id = @city_id;";

            try
            {
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
            }
            catch (SqlException ex)
            {
                throw new DaoException($"SQL exception occurred", ex);
            }

            return city;
        }


        public IList<City> GetCitiesByState(string stateAbbreviation)
        {
            IList<City> cities = new List<City>();

            string sql = "SELECT city_id, city_name, state_abbreviation, population, area FROM city WHERE state_abbreviation = @state_abbreviation " +
                         "ORDER BY city_id;";

            try
            {
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
            }
            catch (SqlException ex)
            {
                throw new DaoException($"SQL exception occurred", ex);
            }

            return cities;
        }

        public City CreateCity(City city)
        {
            City newCity = null;

            string sql = "INSERT INTO city (city_name, state_abbreviation, population, area) " +
                         "OUTPUT INSERTED.city_id VALUES (@city_name, @state_abbreviation, @population, @area);";

            try
            {
                int newCityId;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@city_name", city.CityName);
                    cmd.Parameters.AddWithValue("@state_abbreviation", city.StateAbbreviation);
                    cmd.Parameters.AddWithValue("@population", city.Population);
                    cmd.Parameters.AddWithValue("@area", city.Area);

                    newCityId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                newCity = GetCityById(newCityId);
            }
            catch (SqlException ex)
            {
                throw new DaoException($"SQL exception occurred", ex);
            }

            return newCity;
        }

        public City UpdateCity(City city)
        {
            City updatedCity = null;

            string sql = "UPDATE city SET city_name = @city_name, state_abbreviation = @state_abbreviation, population = @population, area = @area WHERE city_id = @city_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@city_name", city.CityName);
                    cmd.Parameters.AddWithValue("@state_abbreviation", city.StateAbbreviation);
                    cmd.Parameters.AddWithValue("@population", city.Population);
                    cmd.Parameters.AddWithValue("@area", city.Area);
                    cmd.Parameters.AddWithValue("@city_id", city.CityId);

                    int numberOfRows = cmd.ExecuteNonQuery();
                    if (numberOfRows == 0)
                    {
                        throw new DaoException("Zero rows affected, expected at least one");
                    }
                }
                updatedCity = GetCityById(city.CityId);
            }
            catch (SqlException ex)
            {
                throw new DaoException($"SQL exception occurred", ex);
            }

            return updatedCity;
        }

        public int DeleteCityById(int cityId)
        {
            int numberOfRows = 0;

            string sql = "DELETE FROM city WHERE city_id = @city_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@city_id", cityId);

                    numberOfRows = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException($"SQL exception occurred", ex);
            }

            return numberOfRows;
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
