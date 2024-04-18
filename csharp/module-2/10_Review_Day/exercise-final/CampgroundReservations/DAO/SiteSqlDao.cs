using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CampgroundReservations.Exceptions;
using CampgroundReservations.Models;

namespace CampgroundReservations.DAO
{
    public class SiteSqlDao : ISiteDao
    {
        private readonly string connectionString;

        public SiteSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<Site> GetSitesWithRVAccessByParkId(int parkId)
        {
            List<Site> sites = new List<Site>();

            string sql = "SELECT site_id, s.campground_id, site_number, max_occupancy, accessible, max_rv_length, utilities FROM site s " +
                         "INNER JOIN campground c ON c.campground_id = s.campground_id " +
                         "INNER JOIN park p ON p.park_id = c.park_id " +
                         "WHERE max_rv_length > 0 " +
                         "AND p.park_id = @parkId";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@parkId", parkId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Site site = MapRowToSite(reader);
                        sites.Add(site);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return sites;
        }

        public IList<Site> GetSitesAvailableTodayByParkId(int parkId)
        {
            List<Site> sites = new List<Site>();

            string sql = "SELECT site_id, s.campground_id, site_number, max_occupancy, accessible, max_rv_length, utilities " +
                         "FROM site s " +
                         "INNER JOIN campground c ON c.campground_id = s.campground_id " +
                         "WHERE park_id = @parkId " +
                         "AND site_id NOT IN ( " +
                            "SELECT site_id FROM reservation " +
                            "WHERE GETDATE() BETWEEN from_date AND to_date)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@parkId", parkId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Site site = MapRowToSite(reader);
                        sites.Add(site);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return sites;
        }

        private Site MapRowToSite(SqlDataReader reader)
        {
            Site site = new Site();
            site.SiteId = Convert.ToInt32(reader["site_id"]);
            site.CampgroundId = Convert.ToInt32(reader["campground_id"]);
            site.SiteNumber = Convert.ToInt32(reader["site_number"]);
            site.MaxOccupancy = Convert.ToInt32(reader["max_occupancy"]);
            site.Accessible = Convert.ToBoolean(reader["accessible"]);
            site.MaxRVLength = Convert.ToInt32(reader["max_rv_length"]);
            site.Utilities = Convert.ToBoolean(reader["utilities"]);

            return site;
        }
    }
}
